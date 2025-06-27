import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import HeroCarousel from "./components/HeroCarousel";
import Navbar from "./components/Navbar";
import FeaturesSection from "./components/FeaturesSection";
import Footer from "./components/Footer";
import ServicesOverview from "./components/ServicesOverview";
import SidebarWrapper from "./components/SidebarWrapper";
import ProtectedRoute from "./components/ProtectedRoute";   //  👈 NEW

import Register from "./pages/Register";
import Login from "./pages/Login";
import Settings from "./pages/Settings";
import AboutUs from "./pages/AboutUs";

import Dashboard from "./pages/Dashboard";
import DashboardHome from "./pages/DashboardHome";
import Yield from "./pages/Yield";
import Market from "./pages/Market";
import Insight from "./pages/Insight";
import Anomaly from "./pages/Anomaly";

function App() {
  return (
    <Router>
      {/* shows sidebar only on /dashboard routes */}
      <SidebarWrapper />

      <Routes>
        {/* PUBLIC LANDING */}
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

        {/* PUBLIC PAGES */}
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/about" element={<AboutUs />} />

        {/* PROTECTED SETTINGS PAGE */}
        <Route
          path="/settings"
          element={
            <ProtectedRoute>
              <Settings />
            </ProtectedRoute>
          }
        />

        {/* PROTECTED DASHBOARD + nested pages */}
        <Route
          path="/dashboard"
          element={
            <ProtectedRoute>
              <Dashboard />
            </ProtectedRoute>
          }
        >
          <Route index element={<DashboardHome />} />
          <Route path="yield" element={<Yield />} />
          <Route path="market" element={<Market />} />
          <Route path="insight" element={<Insight />} />
          <Route path="anomalyalert" element={<Anomaly />} />
        </Route>

        {/* OPTIONAL: 404 fallback */}
        {/* <Route path="*" element={<Navigate to="/" />} /> */}
      </Routes>
    </Router>
  );
}

export default App;




// import React from "react";
// import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
//
// import HeroCarousel from "./components/HeroCarousel";
// import Navbar from "./components/Navbar";
// import FeaturesSection from "./components/FeaturesSection.jsx";
// import Footer from "./components/Footer.jsx";
// import ServicesOverview from "./components/ServicesOverview.jsx";
// import SidebarWrapper from "./components/SidebarWrapper.jsx";
//
// import Register from "./pages/Register";
// import Login from "./pages/Login";
// import Settings from "./pages/Settings.jsx";
// import AboutUs from "./pages/AboutUs.jsx";
// import Dashboard from "./pages/Dashboard.jsx";
// import DashboardHome from "./pages/DashboardHome";
// import Yield from "./pages/Yield"; // You will create this soon
// import Market from "./pages/Market";
// import Insight from "./pages/Insight";
// import Anomaly from "./pages/Anomaly.jsx";
//
// function App() {
//   return (
//     <Router>
//       <SidebarWrapper />
//       <Routes>
//         <Route
//           path="/"
//           element={
//             <>
//               <Navbar />
//               <HeroCarousel />
//               <FeaturesSection />
//               <section id="services">
//                 <ServicesOverview />
//               </section>
//               <Footer />
//             </>
//           }
//         />
//         <Route path="/register" element={<Register />} />
//         <Route path="/login" element={<Login />} />
//         <Route path="/about" element={<AboutUs />} />
//         <Route path="/settings" element={<Settings />} />
//
//         <Route path="/dashboard" element={<Dashboard />}>
//           <Route index element={<DashboardHome />} />
//           <Route path="yield" element={<Yield />} />
//           <Route path="market" element={<Market />} />
//           <Route path="insight" element={<Insight />} />
//           <Route path="anomalyalert" element={<Anomaly />} />
//         </Route>
//       </Routes>
//     </Router>
//   );
// }
//
// export default App;
