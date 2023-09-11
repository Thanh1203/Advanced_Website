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
        name: "3DCG! SHIN - CẬU BÉ BÚT CHÌ: ĐẠI CHIẾN SIÊU NĂNG LỰC ~ SHUSI BAY",
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
        status: "available",
      },
      {
        id: 2,
        name: "ÁC QUỶ MA SƠ 2",
        img: "11224_103_100001.jpg",
        status: "coming soon",
      },
      {
        id: 3,
        name: "KẺ ẨN DANH",
        img: "11224_103_100001.jpg",
        status: "oder",
      },
      {
        id: 4,
        name: "BỘ ĐÔI BÁO THỦ",
        img: "11224_103_100001.jpg",
        status: "oder",
      },
      {
        id: 5,
        name: "ĐỊA ĐÀNG SỤP ĐỔ",
        img: "11224_103_100001.jpg",
        status: "available",
      },
      {
        id: 6,
        name: "3DCG! SHIN - CẬU BÉ BÚT CHÌ: ĐẠI CHIẾN SIÊU NĂNG LỰC ~ SHUSI BAY",
        img: "11224_103_100001.jpg",
        status: "coming soon",
      },
      {
        id: 7,
        name: "NHÂN DUYÊN TIỀN ĐÌNH",
        img: "11224_103_100001.jpg",
        status: "available",
      },
    ],
    getters: {
      photos: (state) => state.photos,
      products: (state) => state.products,
    },
  },
});
