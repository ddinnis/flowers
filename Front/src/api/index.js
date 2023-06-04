import service from "./axios.js";

export const getBannersData = () => {
  return service.get("/Image/GetImages");
};

export const getFlowersData = (param) => {
  return service.post("/Flowers/GetFlowers", param);
};

// user 相关
export const registerUser = (param) => {
  return service.post("/User/Register", param);
};

export const loginUser = (param) => {
  return service.post("/User/Login", param);
};

export const getValidateCodeImg = (t) => {
  return service.get(`/User/GetValidateCodeImage?t=${t}`);
};

export const CreateOrder = (param) => {
  return service.post("/Order/CreateOrder", param);
};
