<template>
<header>
    <NavigateHeader/>
</header>
<main>
    <gitShopSlide/>
    <div class="gitShopBody">
        <gitShopSelect/>
        <gitShopItemCtn/>
    </div>
</main>
<footer>
    <FooterContact/>
</footer>
</template>
<script setup>
import NavigateHeader from "@/components/HomePage/NavigateHeader.vue";
import FooterContact from "@/components/HomePage/FooterContact.vue";
import gitShopSlide from "@/components/GitShopPage/gitShopSlide.vue";
import gitShopSelect from "@/components/GitShopPage/gitShopSelect.vue";
import gitShopItemCtn from "@/components/GitShopPage/gitShopItemCtn.vue";
</script>
<style scoped>
main {
    background: #f9f6ec;
}
.gitShopBody {
    width: 980px;
    height: 100%;
    padding: 50px 0 ;
    margin: 0 auto;
}
</style>