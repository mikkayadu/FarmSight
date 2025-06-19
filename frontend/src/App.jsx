import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import HeroCarousel from "./components/HeroCarousel";
import Navbar from "./components/Navbar";
import FeaturesSection from "./components/FeaturesSection.jsx";
import Footer from "./components/Footer.jsx";

import Register from "./pages/Register";
import Login from "./pages/Login";
import Settings from "./pages/Settings.jsx";
import AboutUs from "./pages/AboutUs.jsx";
import Dashboard from "./pages/DashBoard.jsx";

function App() {
  return (
    <Router>
      <Routes>
        <Route
          path="/"
          element={
            <>
              <Navbar />
              <HeroCarousel />
              <FeaturesSection />
              <Footer />
            </>
          }
        />
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/settings" element={<Settings />} />
        <Route path="/about" element={<AboutUs />} />
        <Route path="/dashboard" element={<Dashboard />} />
      </Routes>
    </Router>
  );
}

export default App;
