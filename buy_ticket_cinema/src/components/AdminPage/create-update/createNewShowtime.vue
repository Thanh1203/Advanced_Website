<template>
  <div id="createShowtime" class="fl-jc-center">
    <div class="create-container">
      <font-awesome-icon
        :icon="['fas', 'circle-xmark']"
        size="2xl"
        style="color: #000000"
        class="close-create"
        @click="closeCreate"
      />
      <form class="form-create" ref="form" novalidate>
        <div class="mb-3">
          <label class="form-label">{{ infoMovie[1] }}</label>
        </div>
        <div class="row mb-3">
          <div class="col">
            <label class="form-label">Khung giờ</label>
            <input
              type="time"
              class="form-control"
              v-model="showtime.timeslot"
              required
            />
          </div>
          <div class="col">
            <label class="form-label">Số chỗ ngồi</label>
            <input
              type="number"
              class="form-control"
              min="0"
              v-model="showtime.nofSeat"
              required
            />
          </div>
        </div>
        <div class="col-12">
          <button
            class="btn btn-primary"
            type="submit"
            @click.prevent="createShowtime"
          >
            Thêm lịch chiếu
          </button>
        </div>
      </form>
    </div>
  </div>
</template>
<script setup>
import { showtimeCoureApi } from "@/contantApi/contantApi";
import axios from "axios";
import { computed, ref } from "vue";
import { useStore } from "vuex";

const store = useStore();

let showtime = ref({
  timeslot: "",
  nofSeat: "",
});

const form = ref(null);

let infoMovie = computed(() => store.getters["infoShowtimeCreate"]);

const closeCreate = () => {
  store.commit("setInfoShowtimeCreate", "");
  store.commit("setIsCreateShowtime", false);
};

async function createShowtime() {
  if (form.value.checkValidity()) {
    try {
      const formData = new FormData();
      formData.append("idMovie", infoMovie.value[0]);
      formData.append("movieDate", infoMovie.value[1]);
      formData.append("timeslot", showtime.value.timeslot);
      formData.append("nofTickets", showtime.value.nofSeat);
      formData.append("nofSeat", showtime.value.nofSeat);
      await axios
        .post(showtimeCoureApi, formData, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .then(() => {
          showtime.value.timeslot = "";
          showtime.value.nofSeat = "";
          form.value.classList.remove("was-validated");
        })
        .then(() => {
          store.commit("setReloadShowtime", true);
        });
    } catch (error) {
      console.error(error);
    }
  } else {
    form.value.classList.add("was-validated");
  }
}
</script>
<style scoped>
#createShowtime {
  height: 100%;
  width: 100%;
  position: fixed;
  top: 0;
  z-index: 2;
  background-color: transparent;
  backdrop-filter: blur(20px);
  align-items: center;
}

.create-container {
  height: 250px;
  width: 500px;
  border: 1px solid rgb(80, 80, 80);
  border-radius: 20px;
  background-color: white;
  position: relative;
  display: flex;
  justify-content: center;
  align-items: center;
}

.create-container .close-create {
  position: absolute;
  right: 0.7%;
  top: 1%;
  z-index: 3;
}

.create-container .form-create {
  width: 90%;
}
</style>
