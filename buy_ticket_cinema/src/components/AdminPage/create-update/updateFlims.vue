<template>
<div id="updateFlim" class="fl-jc-center">
    <div class="update-container">
        <font-awesome-icon :icon="['fas', 'circle-xmark']" size="2xl" style="color: #000000;" class="close-update" @click="closeUpdate"/>
        <form class="form-update">
            <div class="mb-3">
                <label for="nameFlim" class="form-label">Tên phim</label>
                <input type="text" class="form-control" name="nameFlim" v-model="updateFlim.movieName">
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="typeFlim" class="form-label">Thể loại</label>
                    <input type="text" class="form-control" name="typeFlim" v-model="updateFlim.movieGenre">
                </div>
                <div class="col">
                    <label for="durationFlim" class="form-label">Thời lượng (phút)</label>
                    <input type="number" class="form-control" name="durationFlim" v-model="updateFlim.movieDuration" min="0">
                </div>
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="premiereFlim" class="form-label">Ngày khởi chiếu</label>
                    <input type="Date" class="form-control" name="premiereFlim" v-model="updateFlim.movieOgDate">
                </div>
                <div class="col">
                    <label for="" class="form-label">Trạng thái khởi chiếu</label>
                    <select class="form-select" aria-label="Default select example" v-model="updateFlim.movieStatus">
                        <option value="1" selected>Đang khởi chiếu</option>
                        <option value="2">Sắp khởi chiếu</option>
                    </select>                   
                </div>
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Chọn ảnh của phim</label>
                <input class="form-control" type="file" @change="getImg($event)" accept="image/*">
            </div>
            <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">Tóm tắt nội dung phim</label>
                <textarea class="form-control FormControlTextarea" rows="3" v-model="updateFlim.movieContent"></textarea>
            </div>
            <div class="col-12">
                <button class="btn btn-primary" type="submit" @click.prevent="btnUpdate">Update movie</button>
            </div>
        </form>
    </div>
</div>
</template>
<script setup>
import axios from 'axios';
import {computed, ref, watch } from 'vue';
import { useStore } from 'vuex';
import { filmsCousreApi } from '@/contantApi/contantApi';

const store = useStore()

const closeUpdate = () => {
    store.commit("setIsEditMovie", false)
};

const getFlimUpdate = computed(() => store.getters['infoMovieUpdate'])

watch(getFlimUpdate, (data) => {
    if (data != null) {
        if (data.id != '') {
            updateFlim.value.idMovie = data.id
            updateFlim.value.movieName = data.name
            updateFlim.value.movieGenre = data.genre
            updateFlim.value.movieDuration = data.duration
            updateFlim.value.movieStatus = data.status
            updateFlim.value.movieContent = data.content
        }
    }
})

let updateFlim = ref({
    idMovie:"",
    movieName: "",
    movieGenre: "",
    movieDuration: "",
    movieOgDate: "",
    movieImgFile: null,
    movieStatus: 1,
    movieContent: ""
})

const getImg = (event) => {
    updateFlim.value.movieImgFile = event.target.files[0];
}

async function btnUpdate() {
    const formData = new FormData();
    formData.append('movieName', updateFlim.value.movieName);
    formData.append('movieGenre', updateFlim.value.movieGenre);
    formData.append('movieDuration', updateFlim.value.movieDuration);
    formData.append('movieOgDate', updateFlim.value.movieOgDate);
    formData.append('movieContent', updateFlim.value.movieContent)
    if (updateFlim.value.movieImgFile != null) {
        formData.append('movieImgFile', updateFlim.value.movieImgFile);
    }
    formData.append('movieStatus', updateFlim.value.movieStatus);
    try {
        await axios.patch(`${filmsCousreApi}/${updateFlim.value.idMovie}`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            }
        }).then(() => {
            store.dispatch('loadProducts')
            store.commit('setIsReload', randomIsreload())
        });
    } catch (error) {
        console.error(error)
    }
}

function randomIsreload() {
    const oldValue = store.getters['getIsReload']
    let temp
    do {
        temp = Math.floor(Math.random() * (100 - 1 + 1)) + 1
    } while (temp === oldValue);
    return temp
}
</script>
<style scoped>
#updateFlim {
    height: 100%;
    width: 100%;
    position: fixed;
    top: 0;
    z-index: 2;
    background-color: transparent;
    backdrop-filter: blur(20px);
    align-items: center;
}

.update-container {
    height: 550px;
    width: 700px;
    border: 1px solid rgb(80, 80, 80);
    border-radius: 20px;
    background-color: white;
    position: relative;
    display: flex;
    justify-content: center;
    align-items: center;
}

.update-container .close-update {
    position: absolute;
    right: .7%;
    top: 1%;
    z-index: 3;
}

.update-container .form-update{
    width: 90%;
}
</style>