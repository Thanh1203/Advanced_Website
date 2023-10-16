<template>
    <div id="event">
        <h1 class="title-event">event</h1>
        <div class="event_container">
            <div v-for="(item, index) in events" :key="index" :class="`event${index}`">
                <a :href="`${item.link}`" class="txt_link"><img :src="`${item.img}`" alt=""></a> 
            </div>
        </div>
    </div>
</template>
<script>
import { mapGetters } from 'vuex';

export default {
    computed: {
        ...mapGetters(['events'])
    },

    data() {
        return {}
    }
}
</script>
<style> 
#event {
    height: 885px;
    background-image: url(../../assets/bg_pattern.png);
    background-repeat: repeat;
    text-align: center;
    padding-top: 50px;
    position: relative;
}
.title-event
{
    text-transform: uppercase;
    font-family: Mongolian Baiti;
    font-style: italic;
    font-weight: bolder;
    font-size: 40px;
}
.event_container 
{
    display: grid;
    grid-template-columns: 310px 360px auto;
    grid-template-rows: 310px 310px ;
    margin: 30px auto;
    justify-content: center;
}
.event4
{
    margin-top: -125px;
}
.event5
{
    margin-top: -50px;
}
.event6
{
    margin-top: -120px;
}
</style>