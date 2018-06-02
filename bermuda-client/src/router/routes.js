// layouts
const DefaultLayout = () => import('@/layouts/default')
const AccountLayout = () => import('@/layouts/account')
const ErrorLayout = () => import('@/layouts/error')

// view components
const Home = () => import('@/views/home')
const Shop = () => import('@/views/shop')
const ProductDetail = () => import('@/views/shop/detail')
const ShoppingCart = () => import('@/views/shop/cart')
const Topic = () => import('@/views/topic')
const Search = () => import('@/views/search')
const CurrentCreate = () => import('@/views/current/create')
const SignIn = () => import('@/views/user/signin')
const SignUp = () => import('@/views/user/signup')

// chrildren of RootRoute

const HomeRoute = {
  path: 'home',
  name: 'Home',
  component: Home,
  meta: {
    requiresAuth: false
  }
}

const TopicRoute = {
  path: 'topic',
  name: 'Topic',
  component: Topic,
  meta: {
    requiresAuth: false
  }
}

const ShopRoute = {
  path: 'shop/product',
  name: 'Shop',
  component: Shop,
  meta: {
    requiresAuth: false
  }
}

const ProductDetailRoute = {
  path: 'shop/product/:id',
  name: 'ProductDetail',
  component: ProductDetail,
  meta: {
    requiresAuth: false
  }
}

const ShoppingCartRoute = {
  path: 'shop/cart',
  name: 'ShoppingCart',
  component: ShoppingCart,
  meta: {
    requiresAuth: false
  }
}

const SearchRoute = {
  path: 'search',
  name: 'Search',
  component: Search,
  meta: {
    requiresAuth: false
  }
}

const CurrentCreateRoute = {
  path: 'current/create',
  name: 'CurrentCreate',
  component: CurrentCreate,
  meta: {
    requiresAuth: true
  }
}

// chrildren of AccoutRoute

const SigninRoute = {
  path: 'signin',
  name: 'SignIn',
  component: SignIn,
}

const SignupRoute = {
  path: 'signup',
  name: 'SignUp',
  component: SignUp
}

// root, account and error route

const RootRoute = {
  path: '/',
  component: DefaultLayout,
  redirect: '/home',
  children: [
    HomeRoute,
    TopicRoute,
    ShopRoute,
    ProductDetailRoute,
    ShoppingCartRoute,
    SearchRoute,
    CurrentCreateRoute
  ]
}

const AccountRoute = {
  path: '/account',
  component: AccountLayout,
  children: [
    SigninRoute,
    SignupRoute
  ],
  meta: {
    requiresGuest: true
  }
}

const ErrorRoute = {
  // add 404 route
  path: '*',
  component: ErrorLayout
}

export default [
  RootRoute,
  AccountRoute,
  ErrorRoute
]
