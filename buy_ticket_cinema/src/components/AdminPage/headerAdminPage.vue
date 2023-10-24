<template>
    <header>
        <div class="header_container">
            <div class="admin fl-jc-center">
                <font-awesome-icon :icon="['fas', 'user']" style="color: #000000; font-size: 2.5rem;" />
            </div>
            <div class="logo fl-jc-center">
                <img src="../../assets/favicon.png" alt="logo" style="height: 100%;" @click="backHomePage">
            </div>
            <div class="logout fl-jc-center">
                <button type="button" class="btn btn-outline-danger my-btn-logout" @click.prevent="logout">Logout</button>
            </div>
        </div>
    </header>
</template>
<script setup>
import router from '@/Router/router';

const logout = () => {
    alert("logout")
    router.push("/Admin%20login")
}
const backHomePage = () => {
    router.push('/')
}
</script>
<style scoped>
header {
    width: 100%;
    height: 100px;
    display: flex;
    justify-content: center;
    border-bottom: 1px solid rgb(80, 80, 80);
}

.header_container {
    width: 90%;
    height: 100%;
    display: flex;
    align-items: center;
}

.header_container .admin {
    flex-basis: 10%;
    height: 100%;
    align-items: center;
}

.header_container .logo {
    height: 90%;
    flex-basis: 80%;
    align-items: center;
}

.header_container .logout {
    flex-basis: 10%;
    height: 100%;
    align-items: center;
}
</style>