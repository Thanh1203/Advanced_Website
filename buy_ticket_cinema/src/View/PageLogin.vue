<template>
    <div id="Login">
        <Swiper :modules="modules" :effect="'cube'"
        :cubeEffect="{
            shadow: false,
            slideShadows: false,
        }">
            <SwiperSlide class="Login_slide">
                <LoginCpnVue/>
            </SwiperSlide>
            <SwiperSlide class="Register_slide">
                <RegisterCpnVue/>
            </SwiperSlide>
        </Swiper>
    </div>
</template>
<script>
import LoginCpnVue from '@/components/LoginPage/LoginCpn.vue'
import RegisterCpnVue from '@/components/LoginPage/RegisterCpn.vue'

import { Swiper, SwiperSlide } from 'swiper/vue';
import { EffectCube } from 'swiper/modules';

import 'swiper/css';
import 'swiper/css/effect-cube';

export default {
    components: {
        LoginCpnVue,
        RegisterCpnVue,
        Swiper,
        SwiperSlide
    },
    data() {
        return {}
    },
    setup() {
        return {
            modules: [EffectCube]
        }
    }
}
</script>
<style scoped>
#Login{
    position: relative;
    margin: auto;
    height: 500px;
    width: 400px;
}

.Login_slide {
    height: 500px;
}

.Register_slide{
    height: 500px;
    width: 100%;
}
</style>