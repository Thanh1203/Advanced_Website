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
            <li v-for="(item, index) in listTemp" :key="index" class="item-list fl-jc-center ">
                <div class="item-gr">
                    <div class="item-img"></div>
                    <div class="item-info">
                        <h2>{{ item }}</h2>
                        <p>Thể loại</p>
                        <p>Thời lượng</p>
                        <p>Khởi chiếu</p>
                        <div class="item-showtimes">

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
</template>
<script setup>
import { ref } from 'vue';

const listTemp = ref([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])

const addFilms = () => {
    alert("add films")
}

const editFilms = () => {
    alert("edit films")
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
    width: 250px;
    background-color: aqua;
}

.item-list .item-gr .item-info{
    background-color: aquamarine;
    height: 100%;
    width: calc(100% - 250px - 100px);
}

.item-gr .item-info p {
    margin: 0;
}

.item-gr .item-info .item-showtimes {
    height: 50%;
    background-color: azure;
}

.item-list .item-gr .item-options{
    height: 100%;
    width: 100px;
}

.item-gr .item-option {
    height: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
}
</style>