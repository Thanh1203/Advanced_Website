<template>
<div id="createSlide" class="fl-jc-center">
    <div class="create-container">
        <font-awesome-icon :icon="['fas', 'circle-xmark']" size="2xl" style="color: #000000;" class="close-create" @click="closeCreate"/>
        <form class="form-create" ref="form" novalidate>
            <div class="mb-3">
                <label for="nameFlim" class="form-label">Tên Slide</label>
                <input type="text" class="form-control" name="nameFlim" v-model="newSlide.slideName" required>
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Chọn ảnh của phim</label>
                <input class="form-control" type="file" accept="image/*" @change="getImg($event)" ref="fileinput" required>
            </div>
            <div class="col-12">
                <button class="btn btn-primary" type="submit" @click.prevent="createSlide">Add new slide</button>
            </div>
        </form>
    </div>
</div>
</template>
<script setup>
import { slidesCourseApi } from '@/contantApi/contantApi';
import axios from 'axios';
import {  ref } from 'vue';
import { useStore } from 'vuex';


const store = useStore()

const closeCreate = () => {
    store.commit('setIsCreateSlide', false)
};

let newSlide = ref({
    slideName: '',
    slideImgFile: null
})

let fileinput = ref(null)

const getImg = (ev) => {
    newSlide.value.slideImgFile = ev.target.files[0]
}

const form = ref(null)

async function createSlide() {
    if (form.value.checkValidity()) {
        const formData = new FormData();
        formData.append('slideName', newSlide.value.slideName)
        formData.append('slideImgFile', newSlide.value.slideImgFile)
        try {
            await axios.post(slidesCourseApi, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            }).then(() => {
                newSlide.value.slideName = ''
                newSlide.value.slideImgFile = null
                fileinput.value = null
                form.value.classList.remove('was-validated')
            }).then(() => {
                store.dispatch('loadSlide')
            })
        } catch (error) {
            console.log(error)
        }
    } else {
        form.value.classList.add('was-validated')
    }
}


</script>
<style scoped>
#createSlide {
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
    height: 300px;
    width: 400px;
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