import axios from "axios";
import { eventsCousreApi, filmsCousreApi, slidesCourseApi } from "./contantApi";

function formatDate(inputDate) {
  const date = new Date(inputDate);
  const day = date.getDate();
  const month = date.getMonth() + 1; // Lưu ý rằng tháng trong JavaScript bắt đầu từ 0, nên bạn phải cộng thêm 1.
  const year = date.getFullYear();

  // Đảm bảo rằng chúng ta có dạng "dd/mm/yyyy" bằng cách thêm số 0 nếu cần
  const formattedDay = day < 10 ? `0${day}` : day;
  const formattedMonth = month < 10 ? `0${month}` : month;

  const formattedDate = `${formattedDay}/${formattedMonth}/${year}`;
  return formattedDate;
}

function mapProduct(item) {
  return {
    id: item.idMovie,
    name: item.movieName,
    img: item.movieImage,
    genre: item.movieGenre,
    duration: item.movieDuration,
    premiere: formatDate(item.movieOgDate),
    status: item.movieStatus,
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
    const [products, events, slidePhotos] = await Promise.all([
      axios
        .get(filmsCousreApi)
        .then((response) => response.data.map((item) => mapProduct(item))),
      axios
        .get(eventsCousreApi)
        .then((response) => response.data.map((item) => mapEvents(item))),
      axios
        .get(slidesCourseApi)
        .then((respone) => respone.data.map((item) => mapSlide(item))),
    ]);
    return { products, events, slidePhotos };
  } catch (error) {
    console.error(error);
  }
}
