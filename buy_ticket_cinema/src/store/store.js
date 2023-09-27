import { createStore } from "vuex";
// import dataStrorage from "./dataStrorage";

export const store = createStore({
  state: {
    photos: [
      {
        name: "BẾN PHÀ XÁC SỐNG",
        img: "11224_104_100002.jpg",
      },
      {
        name: "ÁC QUỶ MA SƠ 2",
        img: "11229_105_100007.jpg",
      },
      {
        name: "KẺ ẨN DANH",
        img: "11186_105_100001.jpg",
      },
      {
        name: "BỘ ĐÔI BÁO THỦ",
        img: "11225_105_100001.jpg",
      },
      {
        name: "ĐỊA ĐÀNG SỤP ĐỔ",
        img: "11221_105_100008.jpg",
      },
      {
        name: "3DCG! SHIN - CẬU BÉ BÚT CHÌ",
        img: "11206_105_100007.jpg",
      },
      {
        name: "NHÂN DUYÊN TIỀN ĐÌNH",
        img: "11233_105_100001.jpg",
      },
    ],
    products: [
      {
        id: 1,
        name: "BẾN PHÀ XÁC SỐNG",
        img: "11224_103_100001.jpg",
        genre: "Hồi hộp",
        duration: "119 phút",
        premiere: "15-09-2023",
        status: 1,
      },
      {
        id: 2,
        name: "ÁC QUỶ MA SƠ 2",
        img: "11229_103_100001.jpg",
        genre: "Bí ẩn, Kinh Dị",
        duration: "119 phút",
        premiere: "15-09-2023",
        status: 1,
      },
      {
        id: 3,
        name: "KẺ ẨN DANH",
        img: "11186_103_100002.jpg",
        genre: "Gia đình, Hài, Hành Động",
        duration: "119 phút",
        premiere: "15-09-2023",
        status: 1,
      },
      {
        id: 4,
        name: "BỘ ĐÔI BÁO THỦ",
        img: "11225_103_100002.jpg",
        genre: "Hành Động",
        duration: "119 phút",
        premiere: "15-09-2023",
        status: 1,
      },
      {
        id: 5,
        name: "ĐỊA ĐÀNG SỤP ĐỔ",
        img: "11221_103_100004.jpg",
        genre: "Hành Động, Hồi hộp",
        duration: "119 phút",
        premiere: "15-09-2023",
        status: 1,
      },
      {
        id: 6,
        name: "3DCG! SHIN - CẬU BÉ BÚT CHÌ",
        img: "11206_103_100003.jpg",
        genre: "Hoạt Hình",
        duration: "119 phút",
        premiere: "15-09-2023",
        status: 1,
      },
      {
        id: 7,
        name: "NHÂN DUYÊN TIỀN ĐÌNH",
        img: "11233_103_100002.jpg",
        genre: "Hài, Tình cảm",
        duration: "119 phút",
        premiere: "15-09-2023",
        status: 2,
      },
      {
        id: 8,
        name: "ÁN MẠNG Ở VENICE",
        img: "11231_103_100002.jpg",
        genre: "Kinh Dị, Tâm Lý, Tội phạm",
        duration: "103 phút",
        premiere: "15-09-2023",
        status: 2,
      },
      {
        id: 9,
        name: "TRỪNG PHẠT",
        img: "11245_103_100001.jpg",
        genre: "Hành Động, Tội phạm",
        duration: "91 phút",
        premiere: "15-09-2023",
        status: 2,
      },
      {
        id: 10,
        name: "THANH TRA SÁT NHÂN",
        img: "11200_103_100003.jpg",
        genre: "Hành Động, Tội phạm",
        duration: "102 Phút",
        premiere: "28/07/2023",
        status: 1,
      },
    ],
    events: [
      {
        img: "event1.jpg",
        link: "https://www.lottecinemavn.com/LCHS/Contents/Event/infomation-delivery-event.aspx?EventID=501010000623024",
      },
      {
        img: "event2.jpg",
        link: "https://www.lottecinemavn.com/LCHS/Contents/Event/infomation-delivery-event.aspx?EventID=501010000623025",
      },
      {
        img: "event3.jpg",
        link: "https://www.lottecinemavn.com/LCHS/Contents/Event/infomation-delivery-event.aspx?EventID=501010000623019",
      },
      {
        img: "event4.jpg",
        link: "https://www.lottecinemavn.com/LCHS/Contents/Event/infomation-delivery-event.aspx?EventID=501010000623028",
      },
      {
        img: "event5.jpg",
        link: "https://www.lottecinemavn.com/LCHS/Contents/Event/infomation-delivery-event.aspx?EventID=501010000623022",
      },
      {
        img: "event6.jpg",
        link: "https://www.lottecinemavn.com/LCHS/Contents/Event/infomation-delivery-event.aspx?EventID=101010000623020",
      },
      {
        img: "event7.jpg",
        link: "https://www.lottecinemavn.com/LCHS/Contents/Event/infomation-delivery-event.aspx?EventID=101010000623003",
      },
    ],
  },
  getters: {
    photos: (state) => state.photos,
    products: (state) => state.products,
    events: (state) => state.events,
  },
});
