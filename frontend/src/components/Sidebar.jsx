import React, { useState } from "react";
import { NavLink } from "react-router-dom";
import "../styles/Sidebar.css";
import { FaBars } from "react-icons/fa";

const Sidebar = () => {
  console.log("SIDEBAR RENDERED");
  const [isOpen, setIsOpen] = useState(false);

  const toggleSidebar = () => {
    setIsOpen(!isOpen);
  };

  return (
    <>
      <div className="hamburger" onClick={toggleSidebar}>
        <FaBars size={24} />
      </div>

      <div className={`sidebar ${isOpen ? "open" : ""}`}>
        <h2>FarmSight</h2>
        <NavLink to="/dashboard" onClick={toggleSidebar}>Dashboard</NavLink>
        <NavLink to="/dashboard/yield" onClick={toggleSidebar}>Yield Forecast</NavLink>
        <NavLink to="/dashboard/market" onClick={toggleSidebar}>Market Trends</NavLink>
        <NavLink to="/dashboard/insight" onClick={toggleSidebar}>Farm Insight</NavLink>
      </div>
    </>
  );
};

export default Sidebar;