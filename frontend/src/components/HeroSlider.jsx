// src/components/HeroSlider.jsx
import { Swiper, SwiperSlide } from 'swiper/react'
import { Navigation, Pagination, Autoplay } from 'swiper/modules'
import 'swiper/css'
import 'swiper/css/navigation'
import 'swiper/css/pagination'

import farm1 from '../assets/farm1.jpg'
import farm2 from '../assets/farm2.jpg'
import farm3 from '../assets/farm3.jpg'

const images = [farm1, farm2, farm3]

const HeroSlider = () => {
  return (
    <div className="relative h-screen w-full">
      <Swiper
        modules={[Navigation, Pagination, Autoplay]}
        autoplay={{ delay: 5000 }}
        loop={true}
        pagination={{ clickable: true }}
        navigation
        className="h-full"
      >
        {images.map((src, index) => (
          <SwiperSlide key={index}>
            <div
              className="h-screen w-full bg-cover bg-center bg-no-repeat relative"
              style={{ backgroundImage: `url(${src})` }}
            >
              {/* ✅ White semi-transparent overlay to brighten/fade the image */}
              <div className="absolute inset-0 bg-white/60 mix-blend-overlay"></div>

              {/* ✅ Slide content */}
              <div className="relative z-10 flex flex-col items-center justify-center h-full w-full !text-white text-center px-6">
                <h1 className="text-4xl md:text-5xl font-bold mb-4 drop-shadow-[0_2px_4px_rgba(0,0,0,0.6)]">
                  Empowering Farmers. <br />
                  Ending Losses. Securing Futures…
                </h1>
                <div className="space-x-4">
                  <button className="bg-indigo-600 hover:bg-indigo-700 px-6 py-2 rounded-md font-semibold text-white shadow-md">
                    Register now
                  </button>
                  <button className="border border-white px-6 py-2 rounded-md font-semibold hover:bg-white hover:text-black">
                    Read more →
                  </button>
                </div>
              </div>
            </div>
          </SwiperSlide>
        ))}
      </Swiper>
    </div>
  )
}

export default HeroSlider
