import axios from "axios";
import { eventsCousreApi, filmsCousreApi, slidesCourseApi } from "./contantApi";
// import idMovieLS from "@/localStorage/idMovieLS";

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
    content: item.movieContent,
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

export async function getApiDataMovie() {
  try {
    const products = await axios
      .get(filmsCousreApi)
      .then((response) => response.data.map((item) => mapProduct(item)));
    return products;
  } catch (error) {
    console.error(error);
  }
}
export async function getApiDataMovieWithId(id) {
  try {
    const products = await axios
      .get(`${filmsCousreApi}/${id}`)
      .then((res) => mapProduct(res.data));
    return products;
  } catch (error) {
    console.error(error);
  }
}

export async function getApiDataEvent() {
  try {
    const events = await axios
      .get(eventsCousreApi)
      .then((data) => data.data.map((item) => mapEvents(item)));
    return events;
  } catch (error) {
    console.error(error);
  }
}

export async function getApiDataSlide() {
  try {
    const slidePhotos = await axios
      .get(slidesCourseApi)
      .then((data) => data.data.map((item) => mapSlide(item)));
    return slidePhotos;
  } catch (error) {
    console.error(error);
  }
}
