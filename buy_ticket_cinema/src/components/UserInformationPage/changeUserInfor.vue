<template>
<form class="row g-3">
    <div class="col-md-6">
        <label class="form-label">Số điện thoại</label>
        <input type="text" class="form-control">
    </div>
    <div class="col-md-6">
        <label class="form-label">Họtên</label>
        <input type="text" class="form-control">
    </div>
    <div class="col-md-6">
        <label class="form-label">Email</label>
        <input type="email" class="form-control">
    </div>
    <div class="col-md-6">
        <label class="form-label">Giới tính</label>
        <div class="custom-radios form-control">
            <div>
                <input type="radio" id="male" name="color" value="color-1" checked>
                <label for="male">
                    <span>
                        <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/242518/check-icn.svg" alt="Checked Icon" />
                    </span>
                </label>
                <label for="male">Nam</label>
            </div>

            <div>
                <input type="radio" id="female" name="color" value="color-2">
                <label for="female">
                    <span>
                        <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/242518/check-icn.svg" alt="Checked Icon" />
                    </span>
                </label>
                <label for="female">Nữ</label>
            </div>

            <div>
                <input type="radio" id="other" name="color" value="color-3">
                <label for="other">
                    <span>
                        <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/242518/check-icn.svg" alt="Checked Icon" />
                    </span>
                </label>
                <label for="other">Khác</label>
            </div>  
        </div>
    </div>  
    <div class="col-md-6">
        <label class="form-label">Ngày sinh</label>
        <input type="date" class="form-control">
    </div>
    <div class="col-md-6">
        <label class="form-label">Thành phố</label>
        <select class="form-select" aria-label="Default select example">
            <option selected></option>
            <option v-for="(item, index) in listCity" value="item" :key="index">{{ item }}</option>
        </select>
    </div>
    <div class="md-6">
        <label>Địa chỉ</label>
        <input type="text" class="form-control">
    </div>
    <div class="col-12">
        <button type="button" class="btn btn-primary btnForm">Cập nhật</button>
        <button type="button" class="btn btn-danger" @click="cancelUpdate">Hủy</button>
    </div>
</form>
</template>
<script setup>
import { store } from '@/store/store';
import { ref } from 'vue';
import { cityArr } from './contantLocation';

const listCity = ref(cityArr)

const cancelUpdate = () => {
    store.dispatch("importIsUpdate", 0)
}

</script>
<style scoped>
/* input sex */
.custom-radios {
    display: flex;
    justify-content: space-around;
    border: none;
}
.custom-radios div {
    display: inline-block;
}
.custom-radios input[type=radio] {
  display: none;
}

.custom-radios input[type=radio] + label {
  color: #333;
  font-family: Arial, sans-serif;
  font-size: 14px;
}

.custom-radios input[type=radio] + label span {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 24px;
  height: 24px;
  margin: -1px 4px 0 0;
  vertical-align: middle;
  cursor: pointer;
  border-radius: 50%;
  border: 2px solid #FFFFFF;
  box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.33);
  background-repeat: no-repeat;
  background-position: center;
  text-align: center;
  line-height: 44px;
}

.custom-radios input[type=radio] + label span img {
  opacity: 0;
  transition: all 0.3s ease;
}
.custom-radios input[type=radio] + label span {
    border: 1px solid #A59973;
}

.custom-radios input[type=radio]:checked + label span {
    background-color: #000;
}

.custom-radios input[type=radio]:checked + label span img {
    opacity: 1;
    height: 12px;
    width: 12px;
}

/* input date */
input[type="date"] {
  display:block;
  position:relative;
  font-size:1rem;
  font-family:monospace;
  border:1px solid #8292a2;
  border-radius:0.25rem;
  background:
    white
    url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='20' height='22' viewBox='0 0 20 22'%3E%3Cg fill='none' fill-rule='evenodd' stroke='%23688EBB' stroke-linecap='round' stroke-linejoin='round' stroke-width='2' transform='translate(1 1)'%3E%3Crect width='18' height='18' y='2' rx='2'/%3E%3Cpath d='M13 0L13 4M5 0L5 4M0 8L18 8'/%3E%3C/g%3E%3C/svg%3E")
    right 1rem
    center
    no-repeat;
  
  cursor:pointer;
}
input[type="date"]:focus {
  outline:none;
  border-color:#3acfff;
  box-shadow:0 0 0 0.25rem rgba(0, 120, 250, 0.1);
}

::-webkit-datetime-edit-month-field:hover,
::-webkit-datetime-edit-day-field:hover,
::-webkit-datetime-edit-year-field:hover {
  background:rgba(0, 120, 250, 0.1);
}
::-webkit-datetime-edit-text {
  opacity:0;
}
::-webkit-clear-button,
::-webkit-inner-spin-button {
  display:none;
}
::-webkit-calendar-picker-indicator {
  position:absolute;
  width:2.5rem;
  height:100%;
  top:0;
  right:0;
  bottom:0;
  
  opacity:0;
  cursor:pointer;
  
  color:rgba(0, 120, 250, 1);
  background:rgba(0, 120, 250, 1);
 
}

input[type="date"]:hover::-webkit-calendar-picker-indicator { opacity:0.05; }
input[type="date"]:hover::-webkit-calendar-picker-indicator:hover { opacity:0.15; }

.btnForm {
    margin-right: 20px;
}
</style>