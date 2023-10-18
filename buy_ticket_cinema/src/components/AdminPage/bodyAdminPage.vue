<template>
<main class="fl-jc-center">
    <div class="main-container">
        <nav>
            <ul class="nav-list">
                <li v-for="(item, index) in listSelect" :key="index" @click="changebody(index)">{{ item }}</li>
            </ul>
        </nav>
        <h1>{{ mainTitle }}</h1>
        <div class="addnew_btn" v-show="bodySelect != 3">
            <button type="button" class="btn btn-primary btn-lg my-add-btn" @click.prevent="addNew">
                <font-awesome-icon :icon="['fas', 'plus']" size="xl" style="color: #ffffff; padding-right: 5px;"/>
                {{ btnSelect }}
            </button>
        </div>
        <movieList v-show="bodySelect == 0"/>
        <eventList v-show="bodySelect == 1"/>
        <slideList v-show="bodySelect == 2"/>
        <movieShowTmieBody v-show="bodySelect == 3" @addShowtime="addNew"/>
    </div>
</main>
<!-- * cre-up movie -->
<createNewFlims v-show="isCreateMovieShow" @addFilms="addNew"/>
<updateFlims v-show="isUpdateMovieShow"/>
<!-- *cre-up event -->
<createNewEvents v-show="isCreateEventShow" @addEvent="addNew"/>
<updateEvents v-show="isUpdateEventShow"/>
<!-- *cre-up slide -->
<createNewslide v-show="isCreateSlideShow" @addSlide="addNew"/>
<updateSlide v-show="isUpdateSlideShow"/>
<!-- *cre-up showtime -->
<createNewShowtime v-show="isCreateShowtimeShow" @addShowtime="addNew"/>    

</template>
<script setup>
//* movie
import movieList from './itemAdminPage/movieList.vue';
import createNewFlims from './create-update/createNewFlims.vue';
import updateFlims from './create-update/updateFlims.vue';
//* event
import eventList from './itemAdminPage/eventList.vue';
import createNewEvents from './create-update/createNewEvents.vue';
import updateEvents from './create-update/updateEvents.vue';
//* slide
import slideList from './itemAdminPage/slideList.vue';
import createNewslide from './create-update/createNewSlide.vue';
import updateSlide from './create-update/updateSlide.vue';
//* showtime
import movieShowTmieBody from './itemAdminPage/movieShowTimeBody.vue'
import createNewShowtime from './create-update/createNewShowtime.vue';

import { computed, ref} from 'vue';
import { useStore } from 'vuex';

let listSelect = ref(["Danh Sách Phim", "Danh sách sự kiện", "Danh Sách Slide", "Lịch chiếu phim"]);
let btnSelect = ref('New movie')
let mainTitle = ref("Danh Sách Phim")
let bodySelect = ref(0)

const store = useStore()


//* movie
let isCreateMovieShow = ref(false)
let isUpdateMovieShow = computed(() => store.getters['isEditMovie'])
//* event
let isCreateEventShow = ref(false)
let isUpdateEventShow = computed(() => store.getters['isEditEvent'])
//* slide
let isCreateSlideShow = ref(false)
let isUpdateSlideShow = computed(() => store.getters['isEditSlide'])
//* showtime
let isCreateShowtimeShow = ref(false)


const changebody = (index) => {
    switch (index) {
        case 1:
            mainTitle.value = "Danh Sách Sự Kiện"
            btnSelect.value = "New event"
            bodySelect.value = 1
            break;
        case 2:
            mainTitle.value = "Danh Sách Slide"
            btnSelect.value = "New photo slide"
            bodySelect.value = 2
            break;
        case 3:
            mainTitle.value = "Lịch chiếu phim"
            btnSelect.value = "New show time"
            bodySelect.value = 3
            break;
        default:
            mainTitle.value = "Danh Sách Phim"
            btnSelect.value = "New movie"
            bodySelect.value = 0
            break;
    }
}

const addNew = () => {
    switch (bodySelect.value) {
        case 1:
            isCreateEventShow.value = !isCreateEventShow.value
            break;
        case 2:
            isCreateSlideShow.value = !isCreateSlideShow.value
            break;
        case 3:
            isCreateShowtimeShow.value = !isCreateShowtimeShow.value
            break;
        default:
            isCreateMovieShow.value = !isCreateMovieShow.value
            break;
    }
}
</script>
<style scoped>
main {
    height: 100%;
    width: 100%;
}

.main-container {
    width: 90%;
    height: 100%;
}

.main-container > nav {
    width: 100%;
    display: flex;
    justify-content: center;
    height: 40px;
    border-bottom: 1px solid rgb(80, 80, 80);
}

.main-container .nav-list {
    padding: 0;
    margin: 0;
    width: 80%;
    display: flex;
    justify-content: space-around;
    align-items: center;
}

.main-container .nav-list > li {
    font-weight: 700;
    cursor: pointer;
}

.main-container > h1 {
    margin: 10px 0 30px;
    text-align: center;
    font-weight: 600;
}

.main-container .addnew_btn {
    height: 100px;
    border-top: 1px solid rgb(80, 80, 80);
    display: flex;
    align-items: center;
    justify-content: end;
    padding: 20px;
}

.main-container .addnew_btn .my-add-btn {
    padding: 12px 20px;
}
</style>