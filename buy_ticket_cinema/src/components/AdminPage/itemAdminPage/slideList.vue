<template>
<ul class="list">
    <li v-for="(item, index) in slidePhotos" :key="item.id" class="item-list fl-jc-center" :data-id="`${item.id}`" ref="slideItem">
        <div class="item-gr">
            <div class="item-img">
                <img :src="`${item.img}`" :alt="`${item.name}`">
            </div>
            <div class="items-info">
                <h3>{{ item.name.toUpperCase() }}</h3>
            </div>
            <div class="fl-jc-center slide-option">
                <font-awesome-icon :icon="['fas', 'square-pen']" style="color: #000000; font-size: 2.5rem;" @click="editSlide(index)"/>
            </div>
            <div class="fl-jc-center slide-option">
                <font-awesome-icon :icon="['fas', 'trash-can']" style="color: #000000; font-size: 2.5rem;" @click="deleteSlide(index)"/>
            </div>
        </div>
    </li>
</ul>
</template>
<script setup>
import { slidesCourseApi } from '@/contantApi/contantApi';
import axios from 'axios';
import { computed, onMounted, ref } from 'vue';
import { useStore } from 'vuex';

const store = useStore()

onMounted(() => {
    store.dispatch('loadSlide')
})

const slidePhotos = computed(() => store.getters['slidePhotos'])

const slideItem = ref(null)

function editSlide(index) {
    store.commit('setInfoSlideUpdate', slidePhotos.value[index])
    store.commit('setIsEditSlide', true)
}

async function deleteSlide(index) {
    try {
        const slideDeleteId = slideItem.value[index].attributes[2].value
        await axios.delete(`${slidesCourseApi}/${slideDeleteId}`).then(() => {
            store.dispatch('loadSlide')
        }).then(() => {
            console.log("Successful")
        })
    } catch (error) {
        console.error(error)
    }
}
</script>
<style scoped>
.list {
    padding: 0;
    display: flex;
    flex-direction: column;
    align-items: center;
}
.list .item-list {
    height: 250px;
    width: 100%;
    align-items: center;
}
.list .item-list .item-gr{
    height: 90%;
    width: 90%;
    padding: 10px;
    display: flex;
    border: 1px solid rgb(80, 80, 80);
    border-radius: 10px;
    align-items: center;
    justify-content: center;
}
.item-list .item-gr .item-img{
    height: 100%;
    width: 40%;
    display: flex;
    justify-content: center;
    align-items: center;
}
.item-list .item-gr .item-img > img {
    height: 100%;
}
.item-list .item-gr .items-info{
    height: 100%;
    width: calc(100% - 20% - 40%);
    display: flex;
    flex-direction: column;
    padding: 10px 5px 10px 10px;
    justify-content: center;
}
.item-list .item-gr .slide-option {
    width: 10%;
    height: 100%;
    align-items: center;
}
</style>