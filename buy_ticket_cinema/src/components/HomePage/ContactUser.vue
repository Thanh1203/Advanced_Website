<template>
<div id="contact">
    <div class="contact_group">
        <div class="contact_item" v-for="(item,index) in contactArr" :key="index">
            <a :href="`${item.href}`">
                <img :src="require(`@/assets/${item.img}`)" :alt="`${item.alt}`">
            </a>
        </div>
    </div>
</div>
</template>
<script setup>
import { ref } from 'vue';

const contactArr = ref([
    {
        href: "https://www.youtube.com/lottecinemavietnam",
        img: "contact_youtube.jpg",
        alt: "youtube"
    },
    {
        href: "https://www.facebook.com/lottecinema",
        img: "contact_facebook.jpg",
        alt: "facebook"
    },
    {
        href: "https://www.instagram.com/lottecinema_vietnam/",
        img: "contact_instagram.jpg",
        alt: "instagram"
    },
    {
        href: "",
        img: "contact_notice.png",
        alt: "Notice"
    }
])
</script>
<style scoped>
#contact {
    padding: 50px 0;
    width: 100%;
    border-top: 1px solid #e5e5e5;
}

.contact_group {
    height: 47px;
    width: 980px;
    display: flex;
    justify-content: space-between;
    margin: 0 auto;
}

.contact_item {
    width: 240px;
    height: 100%;
    background-color: aqua;
}
</style>
