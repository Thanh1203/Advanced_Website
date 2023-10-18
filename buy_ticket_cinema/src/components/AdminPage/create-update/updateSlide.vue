<template>
<div id="createSlide" class="fl-jc-center">
    <div class="update-container">
        <font-awesome-icon :icon="['fas', 'circle-xmark']" size="2xl" style="color: #000000;" class="close-update" @click="closeUpdate"/>
        <form class="form-update">
            <div class="mb-3">
                <label for="nameFlim" class="form-label">Tên Slide</label>
                <input type="text" class="form-control" name="nameFlim" v-model="updateSlide.slideName">
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Chọn ảnh của phim</label>
                <input class="form-control" type="file" accept="image/*" @change="getImg($event)">
            </div>
            <div class="col-12">
                <button class="btn btn-primary" type="submit" @click.prevent="btnUpdate">Update slide</button>
            </div>
        </form>
    </div>
</div>
</template>
<script setup>
import { slidesCourseApi } from '@/contantApi/contantApi';
import axios from 'axios';
import { computed, ref, watch } from 'vue';
import { useStore } from 'vuex';

const store = useStore()

const closeUpdate = () => {
    store.commit('setIsEditSlide', false)
};

const getSlideUpdate = computed(() => store.getters['infoSlideUpdate'])

watch(getSlideUpdate, (data) => {
    if (data != null) {
        if (data.id != '') {
            updateSlide.value.idSlide = data.id
            updateSlide.value.slideName = data.name
        }
    }
})

let updateSlide = ref({
    idSlide:'',
    slideName: '',
    slideImgFile: null
})

const getImg = (ev) => {
    updateSlide.value.slideImgFile = ev.target.files[0]
}

async function btnUpdate() {
    const formData = new FormData();
    formData.append('slideName', updateSlide.value.slideName)
    if (updateSlide.value.slideImgFile != null) {
        formData.append('slideImgFile', updateSlide.value.slideImgFile)
    }
    try {
        await axios.patch(`${slidesCourseApi}/${updateSlide.value.idSlide}`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            }
        }).then(() => {
            store.dispatch('loadSlide')
        });
    } catch (error) {
        console.error(error)
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

.update-container {
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