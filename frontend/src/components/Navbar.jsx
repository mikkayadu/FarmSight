// src/components/Navbar.jsx

import { FaChevronDown } from 'react-icons/fa'

const Navbar = () => {
  return (
    <nav className="absolute top-0 left-0 w-full z-50 px-6 py-4 flex justify-between items-center bg-transparent text-white">
      {/* Logo */}
      <div className="flex items-center space-x-2">
        <img src="/logo.svg" alt="FarmSight logo" className="h-8 w-8" />
        <span className="text-xl font-bold">FarmSight</span>
      </div>

      {/* Nav Links */}
      <div className="hidden md:flex space-x-6 text-sm font-medium">
        <a href="#" className="hover:text-indigo-300">Home</a>
        <a href="#" className="hover:text-indigo-300">About us</a>
        <a href="#" className="hover:text-indigo-300">Services</a>
      </div>

      {/* Language + Login */}
      <div className="flex items-center space-x-4">
        <div className="flex items-center space-x-1 cursor-pointer">
          <img src="/us-flag.png" alt="Language" className="h-4 w-6" />
          <FaChevronDown size={10} />
        </div>
        <button className="bg-indigo-600 hover:bg-indigo-700 px-4 py-1.5 rounded-md text-sm font-medium text-white">
          Sign in
        </button>
      </div>
    </nav>
  )
}

export default Navbar
