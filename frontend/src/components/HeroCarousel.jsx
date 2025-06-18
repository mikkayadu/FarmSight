import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { Link } from "react-router-dom";


import React from "react";
import Slider from "react-slick";
import "../styles/HeroCarousel.css";

// import farm4 from "../assets/farm4.jpg";
// import farm5 from "../assets/farm5.jpg";
// import farm6 from "../assets/farm6.jpg";

import farm1 from "../assets/farm1.jpg";
import farm2 from "../assets/farm2.jpg";
// import farm3 from "../assets/farm3.jpg";

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

  // const slides = [farm4, farm5, farm6];
  const slides = [farm1, farm2];

  return (
    <Slider {...settings} className="hero-slider">
  {slides.map((bg, i) => (
    <div key={i} className="hero-slide">
      <img src={bg} alt={`Farm Slide ${i + 1}`} className="slide-image" />
        <div className="overlay">
          <h1>Empowering Farmers. Ending Losses. Securing Futures…</h1>
          <div className="hero-buttons">
            <button><Link to="/register" className="register-btn">Register now</Link></button>
            <button><Link to="/about" className="read-btn"> Read more →</Link> </button>
          </div>
      </div>
    </div>
  ))}
</Slider>
  );
};

export default HeroCarousel;
