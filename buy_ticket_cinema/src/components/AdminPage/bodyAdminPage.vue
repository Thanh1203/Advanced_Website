<template>
<main class="fl-jc-center">
    <div class="main-container">
        <h1>Danh sách phim</h1>
        <div class="add-films">
            <button type="button" class="btn btn-primary btn-lg my-add-btn" @click.prevent="addFilms">
                <font-awesome-icon :icon="['fas', 'plus']" size="xl" style="color: #ffffff; padding-right: 5px;"/>
                New films
            </button>
        </div>
        <ul class="list">
            <li v-for="(item) in products" :key="item.id" class="item-list fl-jc-center ">
                <div class="item-gr">
                    <div class="item-img">
                        <img :src="require(`@/assets/${item.img}`)" :alt="`${item.name}`" style="height: 100%;">
                    </div>
                    <div class="items-info">
                        <h2>{{ item.name }}</h2>
                        <p><span style="font-weight: 600;">Thể loại:</span> {{ item.genre }}</p>
                        <div class="item-info">
                            <p><span style="font-weight: 600;">Thời lượng:</span> {{ item.duration }}</p>
                            <p><span style="font-weight: 600;">Khởi chiếu:</span> {{ item.premiere }}</p>
                        </div>
                        <div class="items-showtimes">
                            <select class="form-select" aria-label="Default select example" style="width: 50%;">
                                <option selected>Chọn lịch chiếu phim</option>
                                <option v-for="(item) in calendar" :key="item.value" :value="`${item.value}`">{{ item.title }}</option>
                            </select>
                            <div class="showtimes-btn">
                                <button type="button" class="btn btn-primary" style="padding: 10px 30px;">Xem</button>
                            </div>
                        </div>
                    </div>
                    <div class="item-options">
                        <div class="item-option">
                            <font-awesome-icon :icon="['fas', 'square-pen']" style="color: #000000; font-size: 2.5rem;" @click="editFilms"/>
                        </div>
                        <div class="item-option">
                            <font-awesome-icon :icon="['fas', 'trash-can']" style="color: #000000; font-size: 2.5rem;" @click="deleteFilms"/>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
    </div>
</main>
<createNewFlims v-show="isCreateShow" @addFilms="addFilms" :isCreateShow="isCreateShow"/>
<updateNewFlims v-show="isUpdateShow" @editFilms="editFilms" :isUpdateShow="isUpdateShow"/>
</template>
<script setup>
import { computed, ref} from 'vue';
import { useStore } from 'vuex';
import createNewFlims from './create-update/createNewFlims'
import updateNewFlims from './create-update/updateNewFlims'

const store = useStore()
const products = computed(() => store.getters['products']);

const calendar = ref([
    {
        value: "T2",
        title: "Thứ 2"
    },
    {
        value: "T3",
        title: "Thứ 3"
    },
    {
        value: "T4",
        title: "Thứ 4"
    },
    {
        value: "T5",
        title: "Thứ 5"
    },
    {
        value: "T6",
        title: "Thứ 6"
    },
    {
        value: "T7",
        title: "Thứ 7"
    },
    {
        value: "CN",
        title: "Chủ nhật"
    },
])

let isCreateShow = ref(false)
let isUpdateShow = ref(false)

const addFilms = () => {
    isCreateShow.value = !isCreateShow.value
}

const editFilms = () => {
    isUpdateShow.value = !isUpdateShow.value
}

const deleteFilms = () => {
    alert("delete films")
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

.main-container > h1 {
    margin: 40px 0 40px;
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
    border-top: 1px solid rgb(80, 80, 80);
    border-left: 1px solid rgb(80, 80, 80);
    border-right: 1px solid rgb(80, 80, 80);
}

.main-container .list .item-list {
    height: 350px;
    width: 100%;
    align-items: center;
}

.list .item-list .item-gr{
    height: 90%;
    width: 90%;
    padding: 10px;
    display: flex;
    border: 1px solid rgb(80, 80, 80);
}

.item-list .item-gr .item-img{
    height: 100%;
    width: 210px;
    display: block;
    text-align: center;
}

.item-list .item-gr .items-info{
    height: 100%;
    width: calc(100% - 210px - 50px);
    display: flex;
    flex-direction: column;
    padding: 10px 5px 10px 10px;
}

.item-gr .items-info .item-info {
    display: flex;
    justify-content: space-between;
}

.item-gr .items-info .item-info > p {
    flex-basis: 50%;
}

.item-gr .items-info .items-showtimes {
    height: 50%;
    flex-grow: 1;
    display: flex;
    align-items: center;
}

.items-info .items-showtimes .showtimes-btn{
    width: 50%;
    display: flex;
    justify-content: center;
}

.item-list .item-gr .item-options{
    height: 100%;
    width: 50px;
}

.item-gr .item-option {
    height: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
}
</style>