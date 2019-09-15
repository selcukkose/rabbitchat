<template>
  <div class="master-page">
    <div class="top-bar">
      <div class="logo">
        <img src="@/assets/images/logo/rabbit_0.svg" />
        <span class="logo-text">{{$t('master_page__logo_name')}}</span>
      </div>
      <div class="login-btns">
        <span class="login-btn">
          {{$t('master_page__sign_in')}}
        </span>
        <span class="login-btn">
          {{$t('master_page__login')}}
        </span>
      </div>
    </div>
    <div class="banner">
      <div class="banner-text-container">
        <div class="banner-text">Takım İletişiminiz</div>
        <div class="banner-type-text-container">
          <div class="banner-type-text">{{bannerText[currentBannerText]}}</div>
        </div>
      </div>
      <div class="banner-image">
        <img src="@/assets/images/MainPage/typingaway.jpg" />
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'MasterPage',
    data: function () {
      return {
        /**
         * Banner Text
         */
        bannerText: [
          this.$tc('master_page__banner_type_text_1'),
          this.$tc('master_page__banner_type_text_2'),
          this.$tc('master_page__banner_type_text_3'),
          this.$tc('master_page__banner_type_text_4'),
          this.$tc('master_page__banner_type_text_5')
        ],
        /**
         * Current Banner Text Index
         */
        currentBannerText: 0
      }
    },
    mounted: function () {
      setInterval(() => {
        if (this.currentBannerText + 1 < this.bannerText.length) {
          this.currentBannerText += 1;
        } else {
          this.currentBannerText = 0;
        }
      }, 4000);
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
