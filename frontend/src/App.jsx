import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import HeroCarousel from "./components/HeroCarousel";
import Navbar from "./components/Navbar";
import FeaturesSection from "./components/FeaturesSection.jsx";
import Footer from "./components/Footer.jsx";
import ServicesOverview from "./components/ServicesOverview.jsx";
import SidebarWrapper from "./components/SidebarWrapper.jsx";

import Register from "./pages/Register";
import Login from "./pages/Login";
import Settings from "./pages/Settings.jsx";
import AboutUs from "./pages/AboutUs.jsx";
import Dashboard from "./pages/Dashboard.jsx";
import DashboardHome from "./pages/DashboardHome";
import Yield from "./pages/Yield"; // You will create this soon
import Market from "./pages/Market";
import Insight from "./pages/Insight";
import Anomaly from "./pages/Anomaly.jsx";

function App() {
  return (
    <Router>
      <SidebarWrapper />
      <Routes>
        <Route
          path="/"
          element={
            <>
              <Navbar />
              <HeroCarousel />
              <FeaturesSection />
              <section id="services">
                <ServicesOverview />
              </section>
              <Footer />
            </>
          }
        />
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/about" element={<AboutUs />} />
        <Route path="/settings" element={<Settings />} />

        <Route path="/dashboard" element={<Dashboard />}>
          <Route index element={<DashboardHome />} />
          <Route path="yield" element={<Yield />} />
          <Route path="market" element={<Market />} />
          <Route path="insight" element={<Insight />} />
          <Route path="anomaly" element={<Anomaly />} />
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
