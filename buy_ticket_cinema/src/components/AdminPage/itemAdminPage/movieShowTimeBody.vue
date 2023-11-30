<template>
  <div class="showtime_container">
    <div class="showtime_ctn_select-movie row g-3">
      <div class="select_movie-lists">
        <select class="form-select" v-model="selectMovie">
          <option value="default">Chọn phim</option>
          <option :value="`${item.id}`" v-for="item in products" :key="item.id">
            {{ item.name }}
          </option>
        </select>
      </div>
      <div class="select_movie-btn">
        <button
          type="button"
          class="btn btn-primary"
          @click.prevent="getMoiveShowTime"
        >
          Get movie
        </button>
      </div>
    </div>
    <div class="select_movie-info" v-show="isSelected">
      <img :src="`${productSeleted.img}`" :alt="`${productSeleted.name}`" />
      <div class="movie_info-gr">
        <h3>{{ productSeleted.name.toUpperCase() }}</h3>
        <div class="movie_info-item">
          <p><strong>Thể loại: </strong>{{ productSeleted.genre }}</p>
          <p><strong>Thời lượng: </strong>{{ productSeleted.duration }}</p>
          <p><strong>Ngày khởi chiếu: </strong>{{ productSeleted.premiere }}</p>
        </div>
      </div>
    </div>
    <div class="showtime_body fl-jc-center" v-show="isSelected">
      <div class="showtime_ctn_select-movie row g-3">
        <div class="select_movie-lists">
          <select class="form-select" v-model="selectShowtime">
            <option value="default">Chọn lịch chiếu</option>
            <option :value="`${item}`" v-for="item in calender" :key="item">
              {{ item }}
            </option>
          </select>
        </div>
        <div class="select_movie-btn">
          <button
            type="button"
            class="btn btn-primary"
            @click.prevent="getShowTime"
          >
            Get showtime
          </button>
        </div>
      </div>
      <div class="showtime_table-ctn">
        <table class="showtime_table">
          <thead class="head_table">
            <tr class="header_table-row">
              <th>Ngày chiếu</th>
              <th>Khung giờ</th>
              <th>Số ghế ngồi</th>
              <th class="table_option"></th>
              <th class="table_option"></th>
            </tr>
          </thead>
          <tbody class="body_table" v-show="isTable">
            <tr
              v-for="(item, index) in showtime"
              :key="item.index"
              class="body_table-row"
            >
              <td>{{ item.moviedate }}</td>
              <td>
                <span v-show="datachangeIndex != index">{{
                  item.timeslot
                }}</span>
                <input
                  type="time"
                  v-model="datachange.timeslot"
                  v-show="datachangeIndex == index"
                />
              </td>
              <td>
                <span v-show="datachangeIndex != index">{{
                  item.nofTickets
                }}</span>
                <input
                  type="number"
                  v-model="datachange.nofTickets"
                  min="0"
                  v-show="datachangeIndex == index"
                />
              </td>
              <td class="table_option-body">
                <font-awesome-icon
                  :icon="['fas', 'pen-to-square']"
                  size="xl"
                  v-show="datachangeIndex != index"
                  @click="editShowtime(index)"
                />
                <button
                  type="button"
                  class="btn btn-success"
                  v-show="datachangeIndex == index"
                  @click.prevent="saveChange(item.row_number)"
                >
                  Lưu
                </button>
              </td>
              <td class="table_option-body">
                <font-awesome-icon
                  :icon="['fas', 'trash-can']"
                  size="xl"
                  v-show="datachangeIndex != index"
                  @click="deleteShowTime(item.row_number)"
                />
                <button
                  type="button"
                  class="btn btn-danger"
                  style="margin: 0 auto"
                  v-show="datachangeIndex == index"
                  @click.prevent="cancelChange"
                >
                  Hủy
                </button>
              </td>
            </tr>
          </tbody>
        </table>
        <div class="showtime_btn" v-show="isTable">
          <button
            type="button"
            class="btn btn-primary"
            @click.prevent="addNewShowtime"
          >
            Thêm mới lịch chiếu
          </button>
        </div>
      </div>
    </div>
    <div class="select_movie-error" v-show="!isSelected">
      <h2 style="margin: 0">Không có dữ liệu !</h2>
    </div>
  </div>
</template>
<script setup>
import axios from "axios";
import { computed, ref, watch } from "vue";
import { useStore } from "vuex";
import { showtimeCoureApi } from "@/contantApi/contantApi";

const store = useStore();

const isPostShowtime = computed(() => store.getters["reloadShowtime"]);
const products = computed(() => store.getters["products"]);
let selectMovie = ref("default");
let selectShowtime = ref("default");
let isSelected = ref(false);
let isTable = ref(false);
let productSeleted = ref({
  id: "",
  name: "",
  img: "",
  genre: "",
  duration: 0,
  premiere: "",
  status: "",
});

watch(isPostShowtime, (reslut) => {
  if (reslut) {
    getShowTime();
    store.commit("setReloadShowtime", false);
  }
});

let showtime = ref([]);
const calender = ref(["Thứ 2", "Thứ 3", "Thứ 4","Thứ 5", "Thứ 6", "Thứ 7", "Chủ nhật"]);
const datachange = ref({
  timeslot: "",
  nofTickets: "",
});
let datachangeIndex = ref(null);
let tempSelectMovie = null;

function getMoiveShowTime() {
  if (selectMovie.value != "default" && selectMovie.value != tempSelectMovie) {
    isSelected.value = true;
    productSeleted.value = products.value.find(
      (item) => item.id == selectMovie.value
    );
    setTimeout(() => {
      scrollToBottom();
    }, 1);
    tempSelectMovie = selectMovie.value;
    isTable.value = false;
    selectShowtime.value = "default";
  } else {
    isSelected.value = false;
  }
}

async function getShowTime() {
  if (selectShowtime.value != "default") {
    await axios
      .get(`${showtimeCoureApi}/${selectMovie.value}/${selectShowtime.value}`)
      .then((data) => {
        return data.data.map((item) => {
          return {
            idMovie: item.idMovie,
            moviedate: item.moviedate,
            timeslot: mapTimeSlot(item.timeslot),
            nofTickets: item.nofTickets,
            row_number: item.row_number,
          };
        });
      })
      .then((data) => {
        showtime.value = data;
        isTable.value = true;
      });
  } else {
    isTable.value = false;
  }
}

//* handle add new showtime
function addNewShowtime() {
  const data = [selectMovie.value, selectShowtime.value];
  store.commit("setInfoShowtimeCreate", data);
  store.commit("setIsCreateShowtime", true);
}

//* handle edit showtime
function editShowtime(index) {
  datachangeIndex.value = index;
}

async function saveChange(rownumber) {
  const formData = new FormData();
  formData.append("timeslot", datachange.value.timeslot);
  formData.append("nofTickets", datachange.value.nofTickets);
  await axios
    .patch(`${showtimeCoureApi}/${selectMovie.value}/${rownumber}`, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    })
    .then(() => {
      getShowTime();
    });
  datachangeIndex.value = null;
}

function cancelChange() {
  datachange.value.timeslot = "";
  datachange.value.nofTickets = "";
  datachangeIndex.value = null;
}

//* handle delete
async function deleteShowTime(index) {
  try {
    if (selectMovie.value != null) {
      await axios
        .delete(`${showtimeCoureApi}/${selectMovie.value}/${index}`)
        .then(() => {
          getShowTime();
        });
    }
  } catch (error) {
    console.error(error);
  }
}

//* other handle
const mapTimeSlot = (value) => value.split("T")[1].substring(0, 5);

function scrollToBottom() {
  window.scroll({
    top: document.body.scrollHeight,
    behavior: "smooth", // Để có hiệu ứng cuộn mượt (thêm vào từ ES6)
  });
}
</script>
<style scoped>
/* container */
.showtime_container {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100%;
}
/* select moive */
.showtime_ctn_select-movie {
  width: 60%;
}

.showtime_ctn_select-movie .select_movie-lists {
  flex-basis: 70%;
}

.showtime_ctn_select-movie .select_movie-btn {
  flex-basis: 30%;
  text-align: center;
}
/* show movie */
.showtime_container .select_movie-info {
  height: 250px;
  width: 60%;
  padding: 2.5% 5%;
  display: flex;
  align-items: center;
  justify-content: space-around;
}

.showtime_container .select_movie-info > img {
  height: 100%;
}

.showtime_container .select_movie-info .movie_info-gr {
  display: flex;
  flex-direction: column;
  padding-left: 5%;
  height: 100%;
  width: 100%;
  justify-content: space-around;
}

.showtime_container .select_movie-info .movie_info-gr * {
  margin: 0;
}

.select_movie-info .movie_info-gr > h3 {
  flex-basis: auto;
}

/* show showtimes */
.showtime_container .showtime_body {
  width: 100%;
  flex-direction: column;
  align-items: center;
}

/* table */
.showtime_container .showtime_body .showtime_table-ctn {
  width: 100%;
  margin-top: 5%;
  min-height: 200px;
}

.showtime_container .showtime_body .showtime_table {
  width: 100%;
  border-collapse: collapse;
  border-radius: 10px;
  overflow: hidden;
}

/* css shared */
.head_table .header_table-row > th,
.body_table .body_table-row > td {
  width: 27%;
  padding: 0 1%;
}

.head_table .header_table-row .table_option,
.body_table .body_table-row .table_option-body {
  width: 9.5%;
  text-align: center;
}
/* header table */
.showtime_body .showtime_table .head_table {
  background-color: rgb(218, 41, 28);
  color: #fff;
  height: 50px;
}
/* body table */
.showtime_table .body_table .body_table-row {
  border-top: 1px solid rgb(218, 41, 28);
  border-bottom: 1px solid rgb(218, 41, 28);
  height: 40px;
}

/* add btn */
.showtime_container .showtime_body .showtime_btn {
  width: 100%;
  display: flex;
  justify-content: center;
  padding: 20px;
}

/* show error */
.showtime_container .select_movie-error {
  color: rgba(255, 0, 0, 0.5);
  display: flex;
  align-items: center;
  height: 100px;
  margin-top: 100px;
}
</style>
