<template>
<header>
    <NavigateHeader/>
</header>
<main>
    <bodyDetailProductPage/>
</main>
<footer>
    <FooterContact/>
</footer>
</template>
<script setup>
import NavigateHeader from "@/components/HomePage/NavigateHeader.vue";
import bodyDetailProductPage from "@/components/DetailPage/bodyDetailProductPage.vue"
import FooterContact from "@/components/HomePage/FooterContact.vue";
import { useStore } from "vuex";
import { onMounted } from "vue";

const store = useStore()

onMounted(() => {
    store.dispatch("loadMovieDetail")
})

</script>
<style scoped></style>