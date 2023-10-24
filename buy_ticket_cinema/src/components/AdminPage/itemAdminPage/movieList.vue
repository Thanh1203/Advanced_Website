<template>
<div class="movie_list-ctn">
    <div class="select_status">
        <span class="select_status-item" @click="movieFilter(0)" :class="{ active: selectStatus === 0 }">Phim đang chiếu</span>
        <span class="select_status-item" @click="movieFilter(1)" :class="{ active: selectStatus === 1 }">Phim sắp chiếu</span>
    </div>
    <div class="movie_list-body">
        <ul class="list">
            <li v-for="(item, index) in products" :key="item?.id" class="item_list fl-jc-center" :data-id="`${item?.id}`" ref="productItem" @click="getMoive(index)">
                <span class="item_name">{{ item?.name?.toUpperCase() }}</span>
            </li>
        </ul>
        <div class="product_info" v-show="movieSelect != null">
            <div class="product_info-gr">
                <div class="product_info-row-1">
                    <div class="product_info-col-1">
                        <img :src="`${movieSelect?.img}`" :alt="`${movieSelect?.name}`">
                    </div>
                    <div class="product_info-col-2">
                        <p class="product_info-name">{{ movieSelect?.name.toUpperCase()}}</p>
                        <p><strong>Thể Loại:</strong> {{ movieSelect?.genre }}</p>
                        <p><strong>Thời lượng:</strong> {{ movieSelect?.duration }} phút</p>
                        <p><strong>Khởi chiếu: </strong>{{ movieSelect?.premiere }}</p>
                    </div>
                </div>
                <div class="product_info-row-2">
                    <span style="color: rgb(218, 41, 28); margin-bottom: 5px;">Nội dung phim</span>
                    <div class="product_info_content">
                        {{ movieSelect?.content }}
                    </div>
                </div>
            </div>
            <div class="produc_info-option">
                <font-awesome-icon :icon="['fas', 'square-pen']" style="color: #0d6efd; font-size: 2.5rem;" @click="editMovie"/>
                <font-awesome-icon :icon="['fas', 'trash-can']" style="color: rgb(218, 41, 28); font-size: 2.5rem;" @click="deleteMovie"/>
            </div>
        </div>
        <div class="product_null" v-show="movieSelect == null">
            <h2>Không có dữ liệu</h2>
        </div>
    </div>
</div>
</template>
<script setup>
import { filmsCousreApi } from '@/contantApi/contantApi';
import axios from 'axios';
import { computed, onMounted, ref, watch } from 'vue';
import { useStore } from 'vuex';

const store = useStore()

onMounted(() => {
    store.dispatch('loadProducts')
})
const isReload = false
watch(isReload, (newValue) => {
    if (newValue) {
        products.value = filterData()
    }
})

// select status movie
let selectStatus = ref(0)
const productsData = computed(() => store.getters['products'])

const products = computed(() => filterData())
const productItem = ref(null)

const movieFilter = (index) => {
    if (selectStatus.value != index) {
        selectStatus.value = index
        movieSelect.value = null
    }
}

const filterData = () => {
    let data
    if (selectStatus.value == 0) {
        data = productsData.value.filter(item => item.status == 1)
    }
    if (selectStatus.value == 1) {
        data = productsData.value.filter(item => item.status == 2)
    }
    return data
}

// select movie
let movieSelectDelete = null
let movieSelect = ref(null)
const getMoive = (index) => {
    movieSelectDelete = productItem.value[index].attributes[2].value
    movieSelect.value = products.value[index]
    store.commit("setInfoMovieUpdate", movieSelect.value)
}

// handle CRUD
function editMovie() {
    store.commit('setIsEditMovie', true)
}

async function deleteMovie() {
    try {
        await axios.delete(`${filmsCousreApi}/${movieSelectDelete}`).then(() => {
            store.dispatch('loadProducts')
        }).then(() => {
            console.log("Successful");
        })
    } catch (error) {
        console.error(error)
    }
}

</script>
<style scoped>
.movie_list-ctn {
    display: flex;
    flex-direction: column;
    align-items: center;
}
.movie_list-ctn .select_status {
    width: 50%;
    height: 50px;
    margin-bottom: 30px;
    display: flex;
    justify-content: space-around;
    align-items: center;
}
.movie_list-ctn .select_status .select_status-item {
    font-weight: 700;
    color: #333;
    padding: .3rem 1rem;
    border-radius: 0.625rem;
    cursor: pointer;
}

.movie_list-ctn .movie_list-body {
    width: 100%;
    display: flex;
    justify-content: space-between;
}
.movie_list-body .list {
    padding: 0;
    display: flex;
    flex-direction: column;
    align-items: center;
    flex-basis: 50%;
    padding: 0 0.5rem;
    border: 1px solid rgb(218, 41, 28);
    border-collapse: collapse;
    padding: 0 2.5%;
}
.list .item_list {
    height: 50px;
    width: 100%;
    align-items: center;
    cursor: pointer;
    border-top: 1px solid rgb(218, 41, 28);
    border-bottom: 1px solid rgb(218, 41, 28);
    margin-bottom: 30px;
    margin-top: 20px;
}
.list .item_list:hover > .item_name {
    color: rgb(218, 41, 28);
}
.list .item_list .item_name {
    font-size: 1.2rem;
    font-weight: 700;
    color: #333;
}
.movie_list-body .product_info {
    flex-basis: 45%;
    padding: 2%;
    display: flex;
    flex-direction: column;
    border: 1px solid rgb(218, 41, 28);
    height: 600px;
}
.movie_list-body .product_info .product_info-gr {
    flex-grow: 1;
    display: flex;
    flex-direction: column;
    justify-content: space-around;
}

.product_info .product_info-gr .product_info-row-1 {
    display: flex;
}
.product_info-gr .product_info-row-1 .product_info-col-1 {
    height: 225px;
}
.product_info-gr .product_info-row-1 .product_info-col-1 > img {
    height: 100%;
}
.product_info-gr .product_info-row-1 .product_info-col-2 {
    padding: 0 2%;
    flex-grow: 1;
}
.product_info-row-1 .product_info-col-2 .product_info-name{
    font-weight: bold;
}
.product_info .product_info-gr .product_info-row-2 {
    height: 200px;
    padding: 1%;
    border-radius: 10px;
    border: 1px solid rgb(0, 0, 0);
    display: flex;
    flex-direction: column;
}
.product_info-gr .product_info-row-2 .product_info_content {
    overflow-y: scroll;
    height: 100%;
}

.product_info .product_info-gr .product_info_content::-webkit-scrollbar {
    background-color: #F5F5F5;
    border-radius: 30px;
    width: 5px;
}
.product_info .product_info-gr .product_info_content::-webkit-scrollbar-thumb {
    border-radius: 30px;
    background-color: rgb(218, 41, 28);
}
.product_info .product_info-gr .product_info_content::-webkit-scrollbar-track {
    background-color: #F5F5F5;
    border-radius: 30px;
}
.movie_list-body .product_info .produc_info-option {
    display: flex;
    justify-content: space-around;
    align-items: center;
    height: 50px;
}

.movie_list-body .product_null {
    display: flex;
    align-items: center;
    justify-content: center;
    height: 100px;
    flex-basis: 45%;
    color: rgb(218, 41, 28);
}
/* other style */
.active {
    color: rgb(218, 41, 28) !important;
    border: 1px solid rgb(218, 41, 28);
}
</style>