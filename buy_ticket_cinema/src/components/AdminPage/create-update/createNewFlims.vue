<template>
<div id="createFlim" class="fl-jc-center">
    <div class="create-container">
        <font-awesome-icon :icon="['fas', 'circle-xmark']" size="2xl" style="color: #000000;" class="close-create" @click="closeCreate"/>
        <form class="form-create" ref="form" novalidate>
            <div class="mb-3">
                <label for="nameFlim" class="form-label">Tên phim</label>
                <input type="text" class="form-control" name="nameFlim" v-model="newFlim.movieName" required>
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="typeFlim" class="form-label">Thể loại</label>
                    <input type="text" class="form-control" name="typeFlim" v-model="newFlim.movieGenre" required>
                </div>
                <div class="col">
                    <label for="durationFlim" class="form-label">Thời lượng (phút)</label>
                    <input type="number" class="form-control" name="durationFlim" v-model="newFlim.movieDuration" min="0" required>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="premiereFlim" class="form-label">Ngày khởi chiếu</label>
                    <input type="Date" class="form-control" name="premiereFlim" v-model="newFlim.movieOgDate" required>
                </div>
                <div class="col">
                    <label for="" class="form-label">Trạng thái khởi chiếu</label>
                    <select class="form-select" aria-label="Default select example" v-model="newFlim.movieStatus" required>
                        <option value="1" selected>Đang khởi chiếu</option>
                        <option value="2">Sắp khởi chiếu</option>
                    </select>                   
                </div>
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Chọn ảnh của phim</label>
                <input class="form-control" type="file" @change="getImg($event)" accept="image/*" required>
            </div>
            <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">Tóm tắt nội dung phim</label>
                <textarea class="form-control FormControlTextarea" rows="3" v-model="newFlim.movieContent" required></textarea>
            </div>
            <div class="col-12">
                <button class="btn btn-primary" type="submit" @click.prevent="createFlim">Add new movie</button>
            </div>
        </form>
    </div>
</div>
</template>
<script setup>
import {ref} from 'vue';
import axios from "axios";
import { useStore } from 'vuex';
import { filmsCousreApi } from '@/contantApi/contantApi';

const store = useStore()

const closeCreate = () => {
    store.commit('setIsCreateMoive', false)
};

const form = ref(null)

let newFlim = ref({
    movieName: "",
    movieGenre: "",
    movieDuration: "",
    movieOgDate: "",
    movieImgFile: "",
    movieStatus: 1,    
    movieContent:''
})

const getImg = (event) => {
    newFlim.value.movieImgFile = event.target.files[0];
}

async function createFlim() {
    if (form.value.checkValidity()) {
        const formData = new FormData();
        formData.append('movieName', newFlim.value.movieName);
        formData.append('movieGenre', newFlim.value.movieGenre);
        formData.append('movieDuration', newFlim.value.movieDuration);
        formData.append('movieOgDate', newFlim.value.movieOgDate);
        formData.append('movieStatus', newFlim.value.movieStatus);
        formData.append('movieImgFile', newFlim.value.movieImgFile);
        formData.append('movieContent', newFlim.value.movieContent)
        try {
            await axios.post(filmsCousreApi, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            }).then(() => {
                newFlim.value.movieName = ""
                newFlim.value.movieGenre = ""
                newFlim.value.movieDuration = ""
                newFlim.value.movieOgDate = ""
                newFlim.value.movieStatus = 1
                newFlim.value.movieImgFile = null
                newFlim.value.movieContent = ""
                form.value.classList.remove('was-validated')
            }).then(() => {
                store.dispatch('loadProducts')
            });
        } catch (error) {
            console.error(error);
        }
    } else {
        form.value.classList.add('was-validated')
    }
}

</script>
<style scoped>
#createFlim {
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

.create-container .close-create {
    position: absolute;
    right: .7%;
    top: 1%;
    z-index: 3;
}

.create-container .form-create{
    width: 90%;
}

</style>