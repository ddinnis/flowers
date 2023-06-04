import axios from "axios";
// import store from "@/store";
// import { getToken } from "@/utils/auth";

const service = axios.create({
  // baseURL: process.env.VUE_APP_BASE_API, // url = base url + request url
  baseURL: "http://localhost:5074/api",
  timeout: 5000, // request timeout
});

service.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers["Authorization"] = "Bearer " + token;
    }
    return config;
  },
  (error) => {
    console.log(error);
    return Promise.reject(error);
  }
);

service.interceptors.response.use(
  (response) => {
    const res = response.data;
    return res;
  },
  (error) => {
    console.log("接口信息报错" + error);
    return Promise.reject(error);
  }
);

export default service;
