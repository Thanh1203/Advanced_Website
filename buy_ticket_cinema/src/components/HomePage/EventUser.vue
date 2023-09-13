<template>
    <div id="event">
        <h1>Event</h1>
        <div class="event_container">
            <div v-for="(item, index) in eventPhoto" :key="index" :class="`event${index}`">
                <img :src="require(`@/assets/${item.img}`)" alt="">
            </div>
        </div>
    </div>
</template>
<script>
const eventPhoto = [
    {
       img:'event1.jpg' 
    },
    {
        img: 'event2.jpg'
    },
    {
        img: 'event3.jpg'
    },
    {
       img:'event4.jpg' 
    },
    {
        img: 'event5.jpg'
    },
    {
        img: 'event6.jpg'
    },
    {
        img: 'event7.jpg'
    },
]

export default {
    data() {
        return {
            eventPhoto,
        }
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

.event_container {
    width: 1275px;
    height: 1500px;
    display: grid;
    grid-template-columns: 325px 325px 325px;
    grid-gap: 10px;
    margin: 0 auto;
}

</style>