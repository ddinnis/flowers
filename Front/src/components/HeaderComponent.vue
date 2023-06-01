<template>
  <div class="container">
    <div class="links">
      <el-link>登录</el-link>
      <el-link>注册</el-link>
      <el-link>个人中心</el-link>
      <el-link>注销</el-link>
    </div>
    <div class="content">
      <div class="logo">
        <el-avatar shape="square" :size="100" fit="fill" :src="url" />
      </div>
      <div class="input">
        <el-input v-model="input" placeholder="商品搜索" />
      </div>
      <div class="customerService">
        <div class="logo">
          <el-icon color="red"><Headset /></el-icon>
        </div>
        <div class="text">在线客服</div>
      </div>
    </div>
    <div class="menu">
      <el-menu
        :default-active="activeIndex"
        class="el-menu-header"
        mode="horizontal"
        router
      >
        <el-menu-item index="/">首页</el-menu-item>
        <el-menu-item index="/love">爱情鲜花</el-menu-item>
        <el-menu-item index="/birthday">生日鲜花</el-menu-item>
        <el-menu-item index="/friend">友情鲜花</el-menu-item>
        <el-menu-item index="/wedding">婚庆鲜花</el-menu-item>
      </el-menu>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";

const url = ref(
  "https://fuss10.elemecdn.com/e/5d/4a731a90594a4af544c0c25941171jpeg.jpeg"
);
const activeIndex = ref("/");
const input = ref("");
</script>

<style lang="less" scoped>
.container {
  .links {
    height: 35px;
    display: flex;
    justify-content: flex-end;
    .el-link {
      margin-right: 20px;
    }
  }
  .content {
    display: flex;
    justify-content: space-around;
    align-items: center;

    .input {
      width: 50%;
    }
    .customerService {
      display: flex;
      justify-content: space-around;
      align-items: center;
      .el-icon {
        display: flex;
        justify-content: center;
        align-items: center;
        margin-right: 5px;
      }
    }
  }

  .el-menu--horizontal {
    justify-content: center;
  }
}
</style>
