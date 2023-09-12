<template>
    <div id="event">
        <h1>Event</h1>
        <div class="event_container">
            <div class="event_group">
                <div :class="`event_item${index}`" v-for="(item, index) in eventPhoto1" :key="index">
                    <img :src="require(`@/assets/${item.img}`)" alt="">
                </div>
            </div>
            <div class="event_group2"></div>
            <div :class="`event_item${index}`" v-for="(item, index) in eventPhoto2" :key="index">
                <img :src="require(`@/assets/${item.img}`)" alt="">
            </div>
        </div>
    </div>
</template>
<script>
const eventPhoto1 = [
    {
       img:'event1.jpg' 
    },
    {
        img: 'event4.jpg'
    },
    // {
    //     img: 'event3.jpg'
    // },
    // {
    //    img:'event4.jpg' 
    // },
    // {
    //     img: 'event5.jpg'
    // },
    // {
    //     img: 'event6.jpg'
    // },
    // {
    //     img: 'event7.jpg'
    // },
]

const eventPhoto2 = [
    {
        img: 'event2.jpg'
    },
    {
        img: 'event5.jpg'
    }
]


export default {
    data() {
        return {
            eventPhoto1,
            eventPhoto2
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
    margin: 0 auto;
    width: 980px;
    border: 1px solid red;
}

.event_group {
    display: flex;
    flex-direction: column;
}
.event_group2 {
    display: flex;
    flex-direction: column;
}

.event_item0 {
    width: 315px;
}

.event_item1 {
    width: 315px;
    height: 164px;
}

</style>