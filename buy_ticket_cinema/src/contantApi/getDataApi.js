import axios from "axios";
import { filmsCousreApi } from "./contantApi";

function formatDate(date) {
  const result = new Date(date);
  return `${result.getDay()}/${result.getMonth()}/${result.getFullYear()}`;
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

// function mapEvents(item) {
//   return {
//     id: item.idEvent,
//     name: item.eventname,
//     img: item.eventimage,
//     link: item.eventlink,
//   };
// }

// function mapSlide(item) {
//   return {
//     id: item.idSlide,
//     name: item.slideName,
//     img: item.slideImage,
//   };
// }

export async function getApiData() {
  try {
    const [products] = await Promise.all([
      axios
        .get(filmsCousreApi)
        .then((response) => response.data.map((item) => mapProduct(item))),
    ]);
    return { products };
  } catch (error) {
    console.error(error);
  }
}
