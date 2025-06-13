import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

import React from "react";
import Slider from "react-slick";
import "../styles/HeroCarousel.css";

import farm1 from "../assets/farm1.jpg";
import farm2 from "../assets/farm2.jpg";
import farm3 from "../assets/farm3.jpg";

const HeroCarousel = () => {
  const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    autoplay: true,
    arrows: true,
    slidesToShow: 1,
    slidesToScroll: 1,
  };

  const slides = [farm1, farm2, farm3];

  return (
    <Slider {...settings} className="hero-slider">
  {slides.map((bg, i) => (
    <div key={i} className="hero-slide">
      <img src={bg} alt={`Farm Slide ${i + 1}`} className="slide-image" />
      <div className="overlay">
        <h1>Empowering Farmers. Ending Losses. Securing Futures…</h1>
        <div className="hero-buttons">
          <button className="register-btn">Register now</button>
          <button className="read-btn">Read more →</button>
        </div>
      </div>
    </div>
  ))}
</Slider>
  );
};

export default HeroCarousel;
