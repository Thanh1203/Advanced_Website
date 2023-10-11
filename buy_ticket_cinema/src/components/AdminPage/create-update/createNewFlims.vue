<template>
<div id="createFlim" class="fl-jc-center">
    <div class="create-container">
        <font-awesome-icon :icon="['fas', 'circle-xmark']" size="2xl" style="color: #000000;" class="close-create" @click="closeCreate"/>
        <form class="form-create">
            <div class="mb-3">
                <label for="nameFlim" class="form-label">Tên phim</label>
                <input type="text" class="form-control" name="nameFlim" v-model="newFlim.tenPhim">
            </div>
            <div class="mb-3">
                <label for="typeFlim" class="form-label">Thể loại</label>
                <input type="text" class="form-control" name="typeFlim" v-model="newFlim.theLoai">
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="durationFlim" class="form-label">Thời lượng (phút)</label>
                    <input type="number" class="form-control" name="durationFlim" v-model="newFlim.thoiLuong" min="0">
                </div>
                <div class="col">
                    <label for="premiereFlim" class="form-label">Ngày khởi chiếu</label>
                    <input type="Date" class="form-control" name="premiereFlim" v-model="newFlim.khoiChieu">
                </div>
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Chọn ảnh của phim</label>
                <input class="form-control" type="file" @change="getImg($event)" accept="image/*">
            </div>
            <div class="mb-3">
                <select class="form-select" aria-label="Default select example" v-model="newFlim.statusFlim">
                    <option value="1" selected>Đang khởi chiếu</option>
                    <option value="2">Sắp khởi chiếu</option>
                </select>   
            </div>
            <div class="col-12">
                <button class="btn btn-primary" type="submit" @click.prevent="createFlim">Thêm mới phim</button>
            </div>
        </form>
    </div>
</div>
</template>
<script setup>
import { defineEmits, ref} from 'vue';
import axios from "axios";
import { filmsCousreApi } from '../../../contantApi/contantApi'

const emit = defineEmits(['addFilms']);

const closeCreate = () => {
    emit('addFilms');
};

let newFlim = ref({
    tenPhim: "",
    imgName: "",
    theLoai: "",
    thoiLuong: "",
    khoiChieu: "",
    statusFlim: "1",    
})

const getImg = (event) => {
    newFlim.value.imgName = event.target.files[0].name  ;
}


async function createFlim() {
    await axios.post(filmsCousreApi, newFlim.value).then(response => {
        console.log(response.data);
    }).catch(error => {
        console.log(error);
    })
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
    right: 1%;
    top: 2%;
    z-index: 3;
}

.create-container .form-create{
    width: 90%;
}

</style>