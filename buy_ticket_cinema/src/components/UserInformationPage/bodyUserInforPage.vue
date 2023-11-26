<template>
<div id="userInfor">
        <div class="userInfor_ctn">
            <div class="userInfor_header">
                <h2>Thông tin tài khoản</h2>
            </div>
            <div class="userInfor_body">
                <div class=userInfor_name>
                    <em>
                        Xin chào
                        <span class="username">Nguyễn Đức Thành</span>
                        !
                    </em>
                    <dl>
                        <dt>Cấp độ thành viên</dt>
                        <dd>Normal</dd>
                    </dl>
                </div>
                <div class="userInfor_content" ref="userInforContent">
                    <userInfor v-show="isUpdateUser == 0"/>
                    <changeUserInfor v-show="isUpdateUser == 1"/>
                    <changePasswordUser v-show="isUpdateUser == 2"/>
                </div>
            </div>
        </div>
    <optionUserInfor v-show="isUpdateUser == 0"/>
</div>
</template>
<script setup>
import { computed, ref, watch } from 'vue';
import { store } from '@/store/store';
import changeUserInfor from './changeUserInfor.vue';
import optionUserInfor from './optionUserInfor.vue';
import userInfor from './userInfor.vue';
import changePasswordUser from './changePasswordUser.vue'

const isUpdateUser = computed(() => store.getters['getIsUpdateUser'])
const userInforContent = ref(null)

watch(isUpdateUser, newValue => {
    if (newValue == 1) {
        userInforContent.value.style.height = '450px'
    } else if (newValue == 2) {
        userInforContent.value.style.height = '310px'
    }
    else {
        userInforContent.value.style.height = '310px'
    }
})

</script>
<style scoped>
#userInfor {
    width: 100%;
}
.userInfor_ctn {
    width: 100%;
    background-color: #f1f0e5;
    display: flex;
    flex-direction: column;
    align-items: center;
    padding-bottom: 50px;
}
.userInfor_ctn .userInfor_header {
    width: 980px;
    height: 65px;
    border-bottom: 2px solid #222;
    margin-top: 30px;
    margin-bottom: 50px;
}

.userInfor_ctn .userInfor_body {
    width: 980px;
}

.userInfor_ctn .userInfor_body .userInfor_name {
    overflow: hidden;
    padding: 17px 30px 17px;
    background: #282e34;
    display: flex;
    justify-content: space-between;
}

.userInfor_ctn .userInfor_body .userInfor_name > em
 {
    font-size: 16px;
    color: #fff;
    font-family: Arial, Helvetica, sans-serif;
    line-height: 20px;
}
.userInfor_body .userInfor_name > em .username {
    color: #cdc197;
}
.userInfor_body .userInfor_name > dl {
    margin: 0;
    font-family: Arial, Helvetica, sans-serif;
    display: flex;
    color: #fff;
    line-height: 20px;
}
.userInfor_body .userInfor_name dl dt {
    padding-right: 15px;
    margin-right: 15px;
    color: #c5c5c5;
    line-height: 20px;
    font-size: 14px;
    font-weight: 400;
    background: url(../../assets/bg_my_line.gif) no-repeat 100% 50%
}
.userInfor_body .userInfor_name dl dd {
    margin-right: 23px;
    font-size: 20px;
    font-weight: bold;
    color: #cdc197;
    font-family: 'linlivertine';
}

.userInfor_ctn .userInfor_body .userInfor_content {
    padding: 24px;
    width: 100%;
    height: 310px;
    background-color: #fff;
    font-family: Arial, Helvetica, sans-serif;
    color: #333;

}
/* transition*/
</style>