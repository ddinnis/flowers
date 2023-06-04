<template>
  <el-dialog
    v-model="isShowLogin"
    title="登录"
    width="30%"
    :before-close="handleClose"
  >
    <el-form :model="form" label-width="120px">
      <el-form-item label="用户名">
        <el-input v-model="form.userName"></el-input>
      </el-form-item>
      <el-form-item label="密码">
        <el-input
          v-model="form.password"
          type="password"
          show-password
        ></el-input>
      </el-form-item>
      <el-form-item label="验证码">
        <el-input v-model="form.validateCode"></el-input>
        <el-image
          class="validate-image"
          style="width: 200px; height: 100px"
          :src="validateCodeImg"
          @click="changeImage"
        ></el-image>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="Submit">确定</el-button>
        <el-button @click="closeLogin">取消</el-button>
      </el-form-item>
    </el-form>
  </el-dialog>
</template>

<script setup>
import { computed, ref, onMounted } from "vue";
import { useStore } from "vuex";
import { loginUser } from "../api";
import { ElMessage } from "element-plus";
import { getGuid, formatToken } from "../global";
const store = useStore();
const isShowLogin = computed(() => {
  return store.state.isShowLogin;
});
const closeLogin = () => {
  store.commit("closeLogin");
};

// 验证码相关
const validateCodeImg = ref("");
const validateKey = getGuid();
onMounted(async () => {
  validateCodeImg.value = `http://localhost:5074/api/User/GetValidateCodeImage?t=${validateKey}`;
});

const changeImage = async () => {
  validateCodeImg.value = `http://localhost:5074/api/User/GetValidateCodeImage?t=${validateKey}`;
};

const form = ref("");
form.value = {
  userName: "",
  password: "",
};

const Submit = async () => {
  var param = {
    userName: form.value.userName,
    password: form.value.password,
    validateKey,
    validateCode: form.value.validateCode,
  };

  const userInfo = await loginUser(param);

  if (userInfo.isSuccess) {
    ElMessage({
      message: "登录成功!",
      type: "success",
    });
    const user = JSON.parse(formatToken(userInfo.data));

    localStorage.setItem("token", JSON.stringify(userInfo.data));
    store.commit("setNickName", user.nickName);
    localStorage.setItem("setNickName", JSON.stringify(userInfo.data.nickName));
    store.commit("closeLogin");
  } else {
    ElMessage.error(userInfo.msg);
  }
};
</script>

<style lang="less" scoped>
.validate-image {
  cursor: pointer;
}
</style>
