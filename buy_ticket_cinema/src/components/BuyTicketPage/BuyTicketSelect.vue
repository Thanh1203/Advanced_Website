<template>
  <div class="buyticket_ctn">
    <div class="selectDay_ctn">
      <div v-for="item in dayInWeek" :key="item.id">
        <input
          type="radio"
          class="btn-check"
          name="optionsDay"
          :id="item.id"
          autocomplete="off"
          :value="item.id"
          @change="selectDay(item.id)"
        />
        <label class="btn btn-outline-danger btnSelectDay" :for="item.id">{{
          item.label
        }}</label>
      </div>
    </div>
    <div class="selectShowtime" v-if="isSelectDay">
      <div class="selectShowtimeItems">
        <h4>Buổi sáng</h4>
        <div v-if="morningListShowTime.length > 0" class="listShowTimeCtn">
          <div v-for="item in morningListShowTime" :key="item">
            <input
              type="radio"
              class="btn-check"
              name="optionsTime"
              :id="item"
              autocomplete="off"
              :value="item"
              @change="selectTime(item)"
            />
            <label class="btn btn-outline-danger btnSelectTime" :for="item">{{
              item
            }}</label>
          </div>
        </div>
        <div v-if="morningListShowTime.length === 0" class="errorShowTime">
          <label class="errorShowTime_label">Không có lịch chiếu !</label>
          <font-awesome-icon
            :icon="['fas', 'calendar-xmark']"
            style="font-size: 40px"
          />
        </div>
      </div>
      <div class="selectShowtimeItems">
        <h4>Buổi chiều</h4>
        <div v-if="afternoonListShowTime.length > 0" class="listShowTimeCtn">
          <div v-for="item in afternoonListShowTime" :key="item">
            <input
              type="radio"
              class="btn-check"
              name="optionsTime"
              :id="item"
              autocomplete="off"
              :value="item"
              @change="selectTime(item)"
            />
            <label class="btn btn-outline-danger btnSelectTime" :for="item">{{
              item
            }}</label>
          </div>
        </div>
        <div v-if="afternoonListShowTime.length === 0" class="errorShowTime">
          <label class="errorShowTime_label">Không có lịch chiếu !</label>
          <font-awesome-icon
            :icon="['fas', 'calendar-xmark']"
            style="font-size: 40px"
          />
        </div>
      </div>
      <div class="selectShowtimeItems">
        <h4>Buổi tối</h4>
        <div v-if="eveningListShowTime.length > 0" class="listShowTimeCtn">
          <div v-for="item in eveningListShowTime" :key="item">
            <input
              type="radio"
              class="btn-check"
              name="optionsTime"
              :id="item"
              autocomplete="off"
              :value="item"
              @change="selectTime(item)"
            />
            <label class="btn btn-outline-danger btnSelectTime" :for="item">
              {{ item }}
            </label>
          </div>
        </div>
        <div v-if="eveningListShowTime.length === 0" class="errorShowTime">
          <label class="errorShowTime_label">Không có lịch chiếu !</label>
          <font-awesome-icon
            :icon="['fas', 'calendar-xmark']"
            style="font-size: 40px"
          />
        </div>
      </div>
    </div>
    <div class="selectSeatCtn" v-if="showTimeSelected">
      <div class="selectSeatDisplay">
        <label>Màn hình</label>
      </div>
      <div class="statusSeat">
        <div class="statusSeatItems">
          <div class="statusSeatItem"></div>
          <label>Ghế trống</label>
        </div>
        <div class="statusSeatItems">
          <div class="statusSeatItem vipSeat"></div>
          <label>Ghế vip</label>
        </div>
        <div class="statusSeatItems">
          <div class="statusSeatItem nomalSeat"></div>
          <label>Ghế đã đặt</label>
        </div>
      </div>
      <div class="selectSeatItems">
        <div v-for="(item, index) in numberSeat" :key="index" class="seatItem">
          <input
            type="checkbox"
            class="btn-check"
            name="optionsTime"
            :id="item"
            autocomplete="off"
            :value="item"
            @change="handleSelectSeat(item)"
            v-model="listCheckboxes"
          />
          <label
            class="btn btn-outline-dark"
            :for="item"
            style="
              display: flex;
              justify-content: center;
              align-items: center;
              height: 53px;
              width: 53px;
            "
            :class="{ vipSeat: item < 40 }"
            >{{ item }}
          </label>
        </div>
      </div>
    </div>
    <div class="orderTicket" v-if="showTimeSelected">
      <button type="button" class="btn buy-btn" @click="orderTicket">
        <font-awesome-icon
          :icon="['fas', 'ticket']"
          size="lg"
          style="color: #ffffff"
        />
        <span style="padding-left: 10px; font-weight: bold">Đặt vé</span>
      </button>
    </div>
  </div>
</template>
<script setup>
import { showtimeCoureApi, ticketCourseApi } from "@/contantApi/contantApi";
import { store } from "@/store/store";
import axios from "axios";
import { computed, ref } from "vue";
const inforMovie = computed(() => store.getters["getMovieBuyTicket"]);
const morningListShowTime = ref([]);
const afternoonListShowTime = ref([]);
const eveningListShowTime = ref([]);
const showTimeSelected = ref();
const numberSeat = ref(0);
const countSeat = ref(0);
const listSelectSeat = ref([]);
const selectedDay = ref("");
const listCheckboxes = ref([]);
const dayInWeek = ref([
  {
    id: "Thứ 2",
    label: "Thứ 2",
  },
  {
    id: "Thứ 3",
    label: "Thứ 3",
  },
  {
    id: "Thứ 4",
    label: "Thứ 4",
  },
  {
    id: "Thứ 5",
    label: "Thứ 5",
  },
  {
    id: "Thứ 6",
    label: "Thứ 6",
  },
  {
    id: "Thứ 7",
    label: "Thứ 7",
  },
  {
    id: "Chủ nhật",
    label: "Chủ nhật",
  },
]);
const dataMovie = ref([]);
const selectDay = async (day) => {
  const idMovie = inforMovie.value.id;
  selectedDay.value = day;
  morningListShowTime.value = [];
  afternoonListShowTime.value = [];
  eveningListShowTime.value = [];
  await getShowTime(day, idMovie);
};

const getShowTime = async (day, id) => {
  try {
    await axios
      .get(`${showtimeCoureApi}/${id}/${day}`)
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
        dataMovie.value = data;
        data.forEach((ele) => {
          checkTimeOfDay(ele.timeslot);
        });
      });
  } catch (error) {
    console.error(error);
  }
};
const mapTimeSlot = (value) => value.split("T")[1].substring(0, 5);

const checkTimeOfDay = (value) => {
  const tempTime = parseInt(value.split(":")[0]);
  const morningStart = 6;
  const afternoonStart = 12;
  const eveningStart = 18;

  if (tempTime >= morningStart && tempTime < afternoonStart) {
    morningListShowTime.value.push(value);
  } else if (tempTime >= afternoonStart && tempTime < eveningStart) {
    afternoonListShowTime.value.push(value);
  } else {
    eveningListShowTime.value.push(value);
  }
};

const selectTime = (time) => {
  showTimeSelected.value = time;
  dataMovie.value.forEach((item) => {
    if (showTimeSelected.value == item.timeslot) {
      numberSeat.value = item.nofTickets;
    }
  });
};

const isSelectDay = computed(() => {
  return (
    morningListShowTime.value.length !== 0 ||
    afternoonListShowTime.value.length !== 0 ||
    eveningListShowTime.value.length !== 0
  );
});

const handleSelectSeat = (value) => {
  if (!listSelectSeat.value.includes(value)) {
    listSelectSeat.value.push(value);
  } else {
    const temp = listSelectSeat.value.indexOf(value);
    if (temp !== -1) listSelectSeat.value.splice(temp, value);
  }
  countSeat.value = listSelectSeat.value.length;
};

const orderTicket = async () => {
  const temp = dataMovie.value.find((ele) => {
    return (
      ele.idMovie === inforMovie.value.id &&
      ele.moviedate === selectedDay.value &&
      ele.timeslot === showTimeSelected.value
    );
  });
  console.log(temp);
  const formData = new FormData();
  const formData2 = new FormData();
  formData.append("nofTickets", temp.nofTickets - countSeat.value);
  formData2.append("idMovie", temp.idMovie);
  formData2.append("idUser", 1);
  formData2.append("seatPosition", listSelectSeat.value.join(","));
  formData2.append("movieDate", temp.moviedate);
  formData2.append("timeslot", temp.timeslot);
  try {
    await axios.patch(
      `${showtimeCoureApi}/${temp.idMovie}/${temp.row_number}`,
      formData,
      {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      }
    );
    await axios
      .post(ticketCourseApi, formData2, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      .then(() => {
        countSeat.value = 0;
        listSelectSeat.value = [];
        listCheckboxes.value = listCheckboxes.value.map(() => false);
      });
  } catch (error) {
    console.log(error);
  }
};
</script>
<style scoped>
.buyticket_ctn {
  padding-top: 24px;
  border-top: 1px solid #d9d6c8;
}
.buyticket_ctn .selectDay_ctn {
  height: 100px;
  display: flex;
  justify-content: space-around;
  align-items: center;
  border-bottom: 1px solid #d9d6c8;
}

.buyticket_ctn .selectShowtime .selectShowtimeItems {
  border-bottom: 1px solid #d9d6c8;
  height: 150px;
  padding: 12px;
}
.selectShowtime .selectShowtimeItems .errorShowTime {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  color: #d9d6c8;
}
.selectShowtimeItems .errorShowTime .errorShowTime_label {
  font-size: 24px;
}
.selectShowtimeItems .listShowTimeCtn {
  display: flex;
}
.buyticket_ctn .selectSeatCtn {
  margin: 24px 0;
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
}
.buyticket_ctn .selectSeatCtn .selectSeatDisplay {
  width: 80%;
  height: 100px;
  background: #fff;
  border: 1px solid #d9d6c8;
  box-shadow: 0 10px 15px 5px #d9d6c8;
  display: flex;
  align-items: center;
  justify-content: center;
}
.selectSeatCtn .selectSeatDisplay > label {
  font-size: 24px;
  letter-spacing: 2px;
}
.buyticket_ctn .selectSeatCtn .selectSeatItems {
  width: 100%;
  border: 1px solid;
  height: 730px;
  margin-top: 50px;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
}
.selectSeatCtn .selectSeatItems .seatItem {
  height: 60px;
  width: 60px;
  margin: 5px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.buyticket_ctn .selectSeatCtn .statusSeat {
  margin-top: 40px;
  width: 50%;
  height: 50px;
  border: 1px solid;
  border-radius: 10px;
  display: flex;
  justify-content: space-around;
  align-items: center;
}
.selectSeatCtn .statusSeat .statusSeatItems {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
}
.statusSeat .statusSeatItems .statusSeatItem {
  height: 25px;
  width: 25px;
  border: 1px solid;
  margin-right: 10px;
}

.buyticket_ctn .orderTicket {
  height: 50px;
  width: 100%;
  margin: 30px 0;
  padding: 0 20px;
  display: flex;
  justify-content: flex-end;
}
.btnSelectDay {
  width: 90px;
  height: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.btnSelectTime {
  width: 90px;
  height: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 0 12px;
}

.vipSeat {
  background-color: #8a2be2;
  color: #fff;
}
.nomalSeat {
  background-color: #838b8b;
}
.buy-btn {
  background-color: rgb(218, 41, 28);
  color: white;
  border: none;
  height: 100%;
  width: 150px;
}
</style>
