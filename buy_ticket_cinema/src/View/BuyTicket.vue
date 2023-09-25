<template>
<div id="BuyTicket">
    <SelectDay/>
    <LocationCinema/>
    <TypeMovie/>
    <CinemaShowTime/>
    <button>Buy ticket</button>
</div>
</template>
<script setup>
import SelectDay from '@/components/BuyTicketPage/SelectDay.vue'
import LocationCinema from '@/components/BuyTicketPage/LocationCinema.vue'
import TypeMovie from '@/components/BuyTicketPage/TypeMovie.vue'
import CinemaShowTime from '@/components/BuyTicketPage/CinemaShowTime.vue'
</script>