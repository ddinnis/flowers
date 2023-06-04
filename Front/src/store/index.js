import { createStore } from "vuex";
const store = createStore({
  state() {
    return {
      isShowLogin: false,
      isShowRegister: false,
      nickName: localStorage.getItem("nickName") ?? "",
    };
  },
  mutations: {
    openLogin(state) {
      state.isShowLogin = true;
      console.log("open login", state);
    },
    closeLogin(state) {
      state.isShowLogin = false;
    },
    openRegister(state) {
      state.isShowRegister = true;
    },
    closeRegister(state) {
      state.isShowRegister = false;
    },
    setNickName(state, nickName) {
      state.nickName = nickName;
    },
  },
});

export default store;
