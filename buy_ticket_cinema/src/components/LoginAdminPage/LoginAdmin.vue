<template>
<div id="LoginAdmin">
    <div class="LoginAdmin-img">
        <img src="../../assets/favicon.png" alt="Logo" class="logo1">
        <img src="../../assets/logo.png" alt="Logo" class="logo2">
    </div>
    <div class="from-loginAdmin">
        <h1 class="title-login">Login</h1>
        <form action="#" class="loginAdmin-form">
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'user']" style="color: #000000;" /></span>
                <div class="form-floating">
                    <input type="text" class="form-control" placeholder="Username" v-model="username">
                    <label>Username</label>
                </div>
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'key']" style="color: #000000;" /></span>
                <div class="form-floating">   
                    <input type="password" class="form-control" placeholder="Password" v-model="password">
                    <label>Password</label>
                </div>
            </div>
            <button type="submit" class="btn btn-primary" @click.prevent="loginadmin">Login</button>
        </form>
    </div>
</div>
</template>
<script setup>
import axios from 'axios';
import { onMounted, ref } from 'vue';
import router from '@/Router/router';


let username = ref('')
let password = ref('')

const courseApi = "http://localhost:5264/Login-Admin";
let logindata = []

onMounted(() => {
    axios.get(courseApi)
        .then(response => {
            logindata = response.data
        })
})

const loginadmin = () => {
    if (handleLogin()) {
        router.push("/Home-Admin")
    }
}

function handleLogin() {
    return logindata.some(item => {
        return item.taikhoan == username.value && item.matkhau == password.value
    })
}
</script>
<style scoped>
#LoginAdmin {
    height: 100%;
    width: 100%;
    background-image: url(../../assets/bg-login-admin.png);
    background-size: cover;
    background-repeat: no-repeat;
    display: flex;
    justify-content: center;
}

.LoginAdmin-img {
    width: 500px;
    height: 500px;
    background-color: white;
    align-self: center;
    border-right: 1px solid rgb(80, 80, 80);
    border-top-left-radius: 10px;
    border-bottom-left-radius: 10px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.LoginAdmin-img .logo1 {
    margin: 0 auto;
    height: 100px;
}

.LoginAdmin-img .logo2 {
    margin: 0 auto;
    height: 73px;
}

.from-loginAdmin {
    height: 500px;
    width: 500px;
    background-color: white;
    border-top-right-radius: 10px;
    border-bottom-right-radius: 10px;
    border-left: 1px solid rgb(80, 80, 80);
    align-self: center;
}

.from-loginAdmin .title-login {
    padding-top: 50px;
    text-align: center;
    color: rgb(218, 41, 28);
    margin-bottom: 40px;
    font-weight: 700;
}
.from-loginAdmin .loginAdmin-form{
    text-align: center;
}

.loginAdmin-form .input-group
{
    width: 450px;
    margin-left:25px;
}

.loginAdmin-form .btn-primary
{
    margin: 0 auto;
    width: 300px;
    background-color: black;
    border: solid 1px white;
    border-radius: 50px;
}
</style>