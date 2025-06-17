import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import HeroCarousel from "./components/HeroCarousel";
import Navbar from "./components/Navbar";
import FeaturesSection from "./components/FeaturesSection.jsx";

import Register from "./pages/Register";
import Login from "./pages/Login";
import Settings from "./pages/Settings.jsx";

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
            </>
          }
        />
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/settings" element={<Settings />} />
      </Routes>
    </Router>
  );
}

export default App;
