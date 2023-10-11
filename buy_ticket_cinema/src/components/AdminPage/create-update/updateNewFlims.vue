<template>
<div id="updateFlim" class="fl-jc-center">
    <div class="update-container">
        <font-awesome-icon :icon="['fas', 'circle-xmark']" size="2xl" style="color: #000000;" class="close-update" @click="closeupdate"/>
        <form class="form-update">
            <div class="mb-3">
                <label for="nameFlim" class="form-label">Tên phim</label>
                <input type="text" class="form-control" name="nameFlim" v-model="updateFlim.name">
            </div>
            <div class="mb-3">
                <label for="typeFlim" class="form-label">Thể loại</label>
                <input type="text" class="form-control" name="typeFlim" v-model="updateFlim.genre">
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="durationFlim" class="form-label">Thời lượng</label>
                    <input type="text" class="form-control" name="durationFlim" v-model="updateFlim.duration">
                </div>
                <div class="col">
                    <label for="premiereFlim" class="form-label">Ngày khởi chiếu</label>
                    <input type="Date" class="form-control" name="premiereFlim" v-model="updateFlim.premiere">
                </div>
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Chọn ảnh của phim</label>
                <input class="form-control" type="file">
            </div>
            <div class="mb-3">
                <select class="form-select" aria-label="Default select example" v-model="updateFlim.status">
                    <option value="1" selected>Đang khởi chiếu</option>
                    <option value="2">Sắp khởi chiếu</option>
                </select>   
            </div>
            <div class="col-12">
                <button class="btn btn-primary" type="submit" @click.prevent="btnUpdate">Cập nhật phim</button>
            </div>
        </form>
    </div>
</div>
</template>
<script setup>
import { defineEmits, ref } from 'vue';

const emit = defineEmits(['editFilms']);

const closeupdate = () => {
    emit('editFilms');
};

let updateFlim = ref({
    name: "",
    img: null,
    genre: "",
    duration: "",
    premiere: "",
    status: "1",
})

const btnUpdate = () => {
    alert('cap nhap thanh cong')
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

.update-container .close-update {
    position: absolute;
    right: 1%;
    top: 2%;
    z-index: 3;
}

.update-container .form-update{
    width: 90%;
}
</style>