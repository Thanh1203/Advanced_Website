<template>
<div id="createEvent" class="fl-jc-center">
    <div class="create-container">
        <font-awesome-icon :icon="['fas', 'circle-xmark']" size="2xl" style="color: #000000;" class="close-create" @click="closeCreate"/>
        <form class="form-create" ref="form" novalidate>
            <div class="mb-3">
                <label for="nameEvent" class="form-label">Tên sự kiện</label>
                <input type="text" class="form-control" name="nameEvent" v-model="newEvent.eventname" required>
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Chọn ảnh của sự kiện</label>
                <input class="form-control" type="file" accept="image/*" @change="getImg($event)" required>
            </div>
            <div class="mb-3">
                <label for="eventLink" class="form-label">Đường link</label>
                <input type="text" class="form-control" name="eventLink" v-model="newEvent.eventlink" required>
            </div>
            <div class="col-12">
                <button class="btn btn-primary" type="submit" @click.prevent="createEvent">Add new event</button>
            </div>
        </form>
    </div>
</div>
</template>
<script setup>
import { eventsCousreApi } from '@/contantApi/contantApi';
import axios from 'axios';
import { ref} from 'vue';
import { useStore } from 'vuex';

const store = useStore()

const closeCreate = () => {
    store.commit('setIsCreateEvent', false)
};

const form = ref(null)

let newEvent = ref({
    eventname: '',
    eventImgFile: '',
    eventlink: ''
})
const getImg = (ev) => {
    newEvent.value.eventImgFile = ev.target.files[0];
}

async function createEvent() {
    if (form.value.checkValidity()) {
        const formData = new FormData();
        formData.append('eventname', newEvent.value.eventname)
        formData.append('eventImgFile', newEvent.value.eventImgFile)
        formData.append('eventlink', newEvent.value.eventlink)
        try {
            await axios.post(eventsCousreApi, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            }).then(() => {
                newEvent.value.eventname = ''
                newEvent.value.eventImgFile = null
                newEvent.value.eventlink = ''
                form.value.classList.remove('was-validated')
            }).then(() => {
                store.dispatch('loadEvents')
            })
        } catch (error) {
            console.error(error)
        }
    } else {
        form.value.classList.add('was-validated')
    }
    
}

</script>

<style scoped>
#createEvent {
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

.create-container .close-create {
    position: absolute;
    right: .7%;
    top: 1%;
    z-index: 3;
}

.create-container .form-create {
    width: 90%;
}
</style>