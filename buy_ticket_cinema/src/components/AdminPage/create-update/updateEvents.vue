<template>
<div id="updateEvent" class="fl-jc-center">
    <div class="update-container">
        <font-awesome-icon :icon="['fas', 'circle-xmark']" size="2xl" style="color: #000000;" class="close-create" @click="closeUpdate"/>
        <form class="form-update">
            <div class="mb-3">
                <label for="nameEvent" class="form-label">Tên sự kiện</label>
                <input type="text" class="form-control" name="nameEvent" v-model="updateEvent.eventname">
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Chọn ảnh của sự kiện</label>
                <input class="form-control" type="file" accept="image/*" @change="getImg($event)">
            </div>
            <div class="mb-3">
                <label for="eventLink" class="form-label">Đường link</label>
                <input type="text" class="form-control" name="eventLink" v-model="updateEvent.eventlink">
            </div>
            <div class="col-12">
                <button class="btn btn-primary" type="submit" @click.prevent="btnUpdate">Update event</button>
            </div>
        </form>
    </div>
</div>
</template>
<script setup>
import { eventsCousreApi } from '@/contantApi/contantApi';
import axios from 'axios';
import { computed, defineEmits, ref, watch } from 'vue';
import { useStore } from 'vuex';

const emit = defineEmits(['editEvent']);
const store = useStore()

const closeUpdate = () => {
    emit('editEvent');
};
const getEventUpdate = computed(() => store.getters['infoEventUpdate'])

watch(getEventUpdate, (data) => {
    if (data != null) {
        if (data.id != '') {
            updateEvent.value.idEvent = data.id
            updateEvent.value.eventname = data.name
            updateEvent.value.eventlink = data.link
        }
    }
})

let updateEvent = ref({
    idEvent:'',
    eventname: '',
    eventImgFile: null,
    eventlink: ''
})

const getImg = (ev) => {
    updateEvent.value.eventImgFile = ev.target.files[0]
}

async function btnUpdate() {
    const formData = new FormData()
    formData.append('eventname', updateEvent.value.eventname)
    if (updateEvent.value.eventImgFile != null) {
        formData.append('eventImgFile', updateEvent.value.eventImgFile)
    }
    formData.append('eventlink', updateEvent.value.eventlink)
    try {
        await axios.patch(`${eventsCousreApi}/${updateEvent.value.idEvent}`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            }
        }).then(() => {
            store.dispatch('loadEvents')
        })
    } catch (error) {
        console.error(error)
    }
}

</script>
<style scoped>
#updateEvent {
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
    height: 500px;
    width: 700px;
    border: 1px solid rgb(80, 80, 80);
    border-radius: 20px;
    background-color: white;
    position: relative;
    display: flex;
    justify-content: center;
    align-items: center;
}

.update-container .close-create {
    position: absolute;
    right: 1%;
    top: 2%;
    z-index: 3;
}

.update-container .form-update {
    width: 90%;
}
</style>