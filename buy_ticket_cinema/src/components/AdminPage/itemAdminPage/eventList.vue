<template>
<ul class="list">
    <li v-for="(item, index) in events" :key="item.id" class="item-list fl-jc-center" :data-id="`${item.id}`" ref="eventItem">
        <div class="item-gr">
            <div class="item-img">
                <img :src="`${item.img}`" :alt="`${item.name}`">
            </div>
            <div class="items-info">
                <h3>Event {{ index + 1 }}: {{ item.name }}</h3>
                <p>{{ item.link }}</p>
                <div class="item-options fl-jc-center">
                    <div class="item-option fl-jc-center">
                        <font-awesome-icon :icon="['fas', 'square-pen']" style="color: #000000; font-size: 2.5rem;" @click="editEvent(index)"/>
                    </div>
                    <div class="item-option fl-jc-center">
                        <font-awesome-icon :icon="['fas', 'trash-can']" style="color: #000000; font-size: 2.5rem;" @click="deleteEvent(index)"/>
                    </div>
                </div>
            </div>
        </div>
    </li>
</ul>
</template>
<script setup>
import { eventsCousreApi } from '@/contantApi/contantApi';
import axios from 'axios';
import { computed, ref } from 'vue';
import { useStore } from 'vuex';

const store = useStore()
const events = computed(() => store.getters['events']);
const eventItem = ref(null)

function editEvent(index) {
    store.commit("setInfoEventUpdate", events.value[index])
    store.commit('setIsEditEvent', true)
}

async function deleteEvent(index) {
    try {
        const eventDeleteId = eventItem.value[index].attributes[2].value
            await axios.delete(`${eventsCousreApi}/${eventDeleteId}`).then(() => {
                store.dispatch('loadEvents')
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
    max-width: 100%;
    width: auto;
    max-height: 100%;
    float: left;
}
.item-list .item-gr .items-info{
    height: 100%;
    width: calc(100% - 40%);
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
.item-list .item-gr .slide-option {
    width: 10%;
    height: 100%;
    align-items: center;
}
.item-gr .item-option {
    width: 50%;
    align-items: center;
}
</style>