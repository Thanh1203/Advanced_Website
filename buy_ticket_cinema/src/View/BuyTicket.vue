<template>
<header>
    <NavigateHeader/>
</header>
<main>
    <div class="bodyBuyticket">
        <MovieInfor/>
        <BuyTicketSelect/>
    </div>
</main>
<footer>
    <FooterContact/>
</footer>
</template>
<script setup>
import NavigateHeader from "@/components/HomePage/NavigateHeader.vue";
import FooterContact from "@/components/HomePage/FooterContact.vue";
import {onMounted} from "vue";
import { store } from "@/store/store";
import MovieInfor from "@/components/BuyTicketPage/MovieInfor.vue"
import BuyTicketSelect from "@/components/BuyTicketPage/BuyTicketSelect.vue";

onMounted(() => {
    store.dispatch("insertMovieBuyTicket")
})

</script>
<style scoped>
main {
    width: 100%;
    display: flex;
    justify-content: center;
}
.bodyBuyticket {
    width: 980px;
}
</style>