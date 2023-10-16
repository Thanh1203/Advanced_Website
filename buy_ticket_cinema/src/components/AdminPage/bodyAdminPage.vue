<template>
<main class="fl-jc-center">
    <div class="main-container">
        <nav>
            <ul class="nav-list">
                <li v-for="(item, index) in listSelect" :key="index" @click="changebody(index)">{{ item }}</li>
            </ul>
        </nav>
        <h1>{{ mainTitle }}</h1>
        <div class="add-films">
            <button type="button" class="btn btn-primary btn-lg my-add-btn" @click.prevent="addNew">
                <font-awesome-icon :icon="['fas', 'plus']" size="xl" style="color: #ffffff; padding-right: 5px;"/>
                {{ btnSelect }}
            </button>
        </div>
        <div v-show="bodySelect == 0">
            <ul class="list">
                <li v-for="(item, index) in products" :key="item.id" class="item-list fl-jc-center" :data-id="`${item.id}`" ref="productItem">
                    <div class="item-gr">
                        <div class="item-img">
                            <img :src="`${item.img}`" :alt="`${item.name}`">
                        </div>
                        <div class="items-info">
                            <h2>{{ item.name.toUpperCase() }}</h2>
                            <p><span style="font-weight: 600;">Thể loại:</span> {{ item.genre }}</p>
                            <div class="item-info">
                                <p><span style="font-weight: 600;">Thời lượng:</span> {{ item.duration }} phút</p>
                                <p><span style="font-weight: 600;">Khởi chiếu:</span> {{ item.premiere }}</p>
                            </div>
                            <div class="item-options fl-jc-center">
                                <div class="item-option fl-jc-center">
                                    <font-awesome-icon :icon="['fas', 'square-pen']" style="color: #000000; font-size: 2.5rem;" @click="editItem(index)"/>
                                </div>
                                <div class="item-option fl-jc-center">
                                    <font-awesome-icon :icon="['fas', 'trash-can']" style="color: #000000; font-size: 2.5rem;" @click="deleteItem(index)"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div> 
        <div v-show="bodySelect == 1">
            <ul class="list">
                <li v-for="(item,index) in events" :key="item.id" class="item-list fl-jc-center item_list-event" :data-id="`${item.id}`" ref="eventItem">
                    <div class="item-gr">
                        <div class="item-img itemImg-event">
                            <img :src="`${item.img}`" :alt="`${item.name}`">
                        </div>
                        <div class="items-info itemsInfo-event">
                            <h3>Event {{ index + 1 }}: {{ item.name }}</h3>
                            <p>{{ item.link }}</p>
                            <div class="item-options fl-jc-center">
                                <div class="item-option fl-jc-center">
                                    <font-awesome-icon :icon="['fas', 'square-pen']" style="color: #000000; font-size: 2.5rem;" @click="editItem(index)"/>
                                </div>
                                <div class="item-option fl-jc-center">
                                    <font-awesome-icon :icon="['fas', 'trash-can']" style="color: #000000; font-size: 2.5rem;" @click="deleteItem(index)"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
        <div v-show="bodySelect == 2">
            <ul class="list">
                <li v-for="(item, index) in slidePhotos" :key="item.id" class="item-list fl-jc-center item_list-event" :data-id="`${item.id}`" ref="slideItem">
                    <div class="item-gr">
                        <div class="item-img itemImg-slide">
                            <img :src="`${item.img}`" :alt="`${item.name}`">
                        </div>
                        <div class="items-info items_info-slide">
                            <h3>{{ item.name.toUpperCase() }}</h3>
                        </div>
                        <div class="fl-jc-center slide-option">
                            <font-awesome-icon :icon="['fas', 'square-pen']" style="color: #000000; font-size: 2.5rem;" @click="editItem(index)"/>
                        </div>
                        <div class="fl-jc-center slide-option">
                            <font-awesome-icon :icon="['fas', 'trash-can']" style="color: #000000; font-size: 2.5rem;" @click="deleteItem(index)"/>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</main>
<createNewFlims v-show="isCreateMovieShow" @addFilms="addNew"/>
<updateFlims v-show="isUpdateMovieShow" @editFilms="editItem"/>
<createNewEvents v-show="isCreateEventShow" @addEvent="addNew"/>
<updateEvents v-show="isUpdateEventShow" @editEvent="editItem"/>
<createNewslide v-show="isCreateSlideShow" @addSlide="addNew"/>
<updateSlide v-show="isUpdateSlideShow" @editSlide="editItem"/>
</template>
<script setup>
import createNewFlims from './create-update/createNewFlims.vue';
import updateFlims from './create-update/updateFlims.vue';
import createNewEvents from './create-update/createNewEvents.vue';
import updateEvents from './create-update/updateEvents.vue';
import createNewslide from './create-update/createNewSlide.vue';
import updateSlide from './create-update/updateSlide.vue';

import { computed, ref } from 'vue';
import { useStore } from 'vuex';
import axios from 'axios';
import { eventsCousreApi, filmsCousreApi, slidesCourseApi } from '@/contantApi/contantApi';

let listSelect = ref(["Danh Sách Phim", "Danh sách sự kiện", "Danh Sách Slide", "Lịch chiếu phim"]);
let btnSelect = ref('New movie')
let mainTitle = ref("Danh Sách Phim")
let bodySelect = ref(0)
const store = useStore()
const products = computed(() => store.getters['products']);
const events = computed(() => store.getters['events']);
const slidePhotos = computed(()=> store.getters['slidePhotos'])
const productItem = ref(null)
const eventItem = ref(null)
const slideItem = ref(null)

let isCreateMovieShow = ref(false)
let isUpdateMovieShow = ref(false)
let isCreateEventShow = ref(false)
let isUpdateEventShow = ref(false)
let isCreateSlideShow = ref(false)
let isUpdateSlideShow = ref(false)

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
        default:
            isCreateMovieShow.value = !isCreateMovieShow.value
            break;
    }
    
}

const editItem = (index) => {
    if (bodySelect.value == 0) {
        store.commit("setInfoMovieUpdate", products.value[index])
        isUpdateMovieShow.value = !isUpdateMovieShow.value
    }
    if (bodySelect.value == 1) {
        store.commit("setInfoEventUpdate", events.value[index])
        isUpdateEventShow.value = !isUpdateEventShow.value
    }
    if (bodySelect.value == 2) {
        store.commit('setInfoSlideUpdate', slidePhotos.value[index])
        isUpdateSlideShow.value = !isUpdateSlideShow.value
    }
}


async function deleteItem(index) {
    if (bodySelect.value == 0) {
        const productDeleteId = productItem.value[index].attributes[2].value
        await axios.delete(`${filmsCousreApi}/${productDeleteId}`).then(() => {
            store.dispatch('loadProducts')
        }).then(() => {
            console.log("Successful");
        })
    }
    if (bodySelect.value == 1) {
        const eventDeleteId = eventItem.value[index].attributes[2].value
        await axios.delete(`${eventsCousreApi}/${eventDeleteId}`).then(() => {
            store.dispatch('loadEvents')
        }).then(() => {
            console.log("Successful");
        })        
    }
    if (bodySelect.value == 2) {
        const slideDeleteId = slideItem.value[index].attributes[2].value
        await axios.delete(`${slidesCourseApi}/${slideDeleteId}`).then(() => {
            store.dispatch('loadSlide')
        }).then(() => {
            console.log("Successful")
        })
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

.main-container .add-films {
    height: 100px;
    border-top: 1px solid rgb(80, 80, 80);
    display: flex;
    align-items: center;
    justify-content: end;
    padding: 20px;
}

.main-container .add-films .my-add-btn {
    padding: 12px 20px;
}

.main-container .list {
    padding: 0;
    display: flex;
    flex-direction: column;
    align-items: center;
    border: 1px solid rgb(80, 80, 80);
}

.main-container .list .item-list {
    height: 420px;
    width: 100%;
    align-items: center;
}

.main-container .list .item_list-event {
    width: 100%;
    height: auto;
}

.list .item-list .item-gr{
    height: 90%;
    width: 90%;
    padding: 10px;
    display: flex;
    border: 1px solid rgb(80, 80, 80);
    align-items: center;
}


.item-list .item-gr .item-img{
    height: 100%;
    width: 250px;
    display: flex;
    justify-content: center;
    align-items: center;
}

.item-list .item-gr .item-img > img {
    max-height: 350px;
}

.item-list .item-gr .itemImg-event{
    width: 40%;
}

.item-list .item-gr .itemImg-slide{
    width: 40%;
}

.item-list .item-gr .itemImg-event > img {
    max-width: 100%;
    width: auto;
    max-height: 100%;
    float: left;
}

.item-list .item-gr .itemImg-slide > img {
    width: 100%;
    height: auto;
}

.item-list .item-gr .items-info{
    height: 100%;
    width: calc(100% - 250px);
    display: flex;
    flex-direction: column;
    padding: 10px 5px 10px 10px;
}

.item-list .item-gr .itemsInfo-event{
    width: calc(100% - 40%);
}

.item-list .item-gr .items_info-slide{
    width: calc(100% - 20% - 40%);
}

.item-gr .items-info .item-info {
    display: flex;
    justify-content: space-between;
}

.item-gr .items-info .item-info > p {
    flex-basis: 50%;
}

.item-list .item-gr .item-options{
    width: 100%;
    height: 50px;
    align-items: center;
}

.item-list .item-gr .slide-option {
    width: 10%;
    height: 100%;
}

.item-gr .item-option {
    width: 50%;
    align-items: center;
}

</style>