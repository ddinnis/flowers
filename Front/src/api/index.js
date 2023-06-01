import service from "./axios.js";

export const getBannersData = () => {
  return service.get("/Image/GetImages");
};

export const getFlowersData = () => {
  return service.get("/Flowers/GetFlowers");
};
