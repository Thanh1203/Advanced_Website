<template>
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
                        <font-awesome-icon :icon="['fas', 'square-pen']" style="color: #000000; font-size: 2.5rem;" @click="editMovie(index)"/>
                    </div>
                    <div class="item-option fl-jc-center">
                        <font-awesome-icon :icon="['fas', 'trash-can']" style="color: #000000; font-size: 2.5rem;" @click="deleteMovie(index)"/>
                    </div>
                </div>
            </div>
        </div>
    </li>
</ul>
</template>
<script setup>
import { filmsCousreApi } from '@/contantApi/contantApi';
import axios from 'axios';
import { computed, onMounted, ref } from 'vue';
import { useStore } from 'vuex';

const store = useStore()

onMounted(() => {
    store.dispatch('loadProducts')
})
const products = computed(() => store.getters['products']);

const productItem = ref(null)

function editMovie(index) {
    store.commit("setInfoMovieUpdate", products.value[index])
    store.commit('setIsEditMovie', true)
}

async function deleteMovie(index) {
    try {
        const productDeleteId = productItem.value[index].attributes[2].value
        await axios.delete(`${filmsCousreApi}/${productDeleteId}`).then(() => {
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
    width: 145px;
    display: flex;
    justify-content: center;
    align-items: center;
}
.item-list .item-gr .item-img > img {
    height: 100%;
}
.item-list .item-gr .items-info{
    height: 100%;
    width: calc(100% - 250px);
    display: flex;
    flex-direction: column;
    padding: 10px 5px 10px 10px;
    justify-content: space-between;
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
.item-gr .item-option {
    width: 50%;
    align-items: center;
}
</style>