<template>
<div class="userInfor_options">
    <div class="userInfor_options-ctn"> 
        <div @click="changeUserInfo">
            <font-awesome-icon :icon="['fas', 'gear']" size="2xl" style="color:#CDC197;" />
            Thay đổi thông tin thành viên
            <font-awesome-icon :icon="['fas', 'circle-arrow-right']" size="sm" style="color:#000;"/>
        </div>
        <div @click="changeUserPassword">
            <font-awesome-icon :icon="['fas', 'key']" size="2xl"  style="color:#CDC197;"/>
            Thay đổi mật khẩu
            <font-awesome-icon :icon="['fas', 'circle-arrow-right']" size="sm" style="color:#000;"/>
        </div>
        <div>
            <font-awesome-icon :icon="['fas', 'arrow-right-from-bracket']" size="2xl" style="color:#CDC197;"/>
            Ly khai
            <font-awesome-icon :icon="['fas', 'circle-arrow-right']" size="sm" style="color:#000;"/>
        </div>
    </div>
</div>
</template>
<script setup>
import { store } from '@/store/store';

const changeUserInfo = () => {
    store.dispatch("importIsUpdate", 1)
}

const changeUserPassword = () => {
    store.dispatch("importIsUpdate", 2)
}
</script>
<style scoped>
.userInfor_options {
    margin: 30px 0;
    width: 100%;
    height: 79px;
    background-color: #fff;
}

.userInfor_options .userInfor_options-ctn {
    width: 980px;
    height: 100%;
    margin: 0 auto;
    display: flex;
    justify-content: center;
    border-top: 1px solid #dedede;
    border-bottom: 1px solid #dedede;
}

.userInfor_options .userInfor_options-ctn div {
    padding: 21px 25px 22px 25px;
    width: calc(100% / 3);
    display: flex;
    align-items: center;
    justify-content: space-between;
    color: #666;
    font-weight: bold;
    font-size: 14px;
    cursor: pointer;
}

.userInfor_options .userInfor_options-ctn div:first-child {
    border-left: 1px solid #dedede;
    border-right: 1px solid #dedede;
}

.userInfor_options .userInfor_options-ctn div:last-child {
    border-right: 1px solid #dedede;
    border-left: 1px solid #dedede;
}
</style>