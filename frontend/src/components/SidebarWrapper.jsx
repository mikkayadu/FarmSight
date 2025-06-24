// src/components/SidebarWrapper.jsx
import React from "react";
import { useLocation } from "react-router-dom";
import Sidebar from "./Sidebar";

const SidebarWrapper = () => {
  const { pathname } = useLocation();
  // Only render sidebar (and hamburger) on /dashboard routes
  if (!pathname.startsWith("/dashboard")) return null;
  return <Sidebar />;
};

export default SidebarWrapper;
