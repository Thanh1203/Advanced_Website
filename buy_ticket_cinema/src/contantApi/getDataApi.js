import axios from "axios";
import {
  filmsCousreApi,
  showTimesCourseApi,
  eventCourseApi,
  slideCourseApi,
} from "./contantApi";

function formatDate(date) {
  const result = new Date(date);
  return `${result.getDay()}/${result.getMonth()}/${result.getFullYear()}`;
}

function mapProduct(item) {
  return {
    id: item.idPhim,
    name: item.tenPhim,
    img: item.imgName,
    genre: item.theLoai,
    duration: item.thoiLuong,
    premiere: formatDate(item.khoiChieu),
    status: item.statusFlim,
  };
}

function mapEvents(item) {
  return {
    id: item.idEvent,
    name: item.eventname,
    img: item.eventimage,
    link: item.eventlink,
  };
}

function mapSlide(item) {
  return {
    id: item.idSlide,
    name: item.slideName,
    img: item.slideImage,
  };
}

export async function getApiData() {
  try {
    const [products, showTimes, events, slidePhotos] = await Promise.all([
      axios
        .get(filmsCousreApi)
        .then((response) => response.data.map((item) => mapProduct(item))),
      axios.get(showTimesCourseApi).then((response) => response.data),
      axios
        .get(eventCourseApi)
        .then((response) => response.data.map((item) => mapEvents(item))),
      axios
        .get(slideCourseApi)
        .then((response) => response.data.map((item) => mapSlide(item))),
    ]);
    return { products, showTimes, events, slidePhotos };
  } catch (error) {
    console.error(error);
  }
}
