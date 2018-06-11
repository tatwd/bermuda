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
const TopicDetail = () => import('@/views/topic/detail')
const NoticeCreate = () => import('@/views/notice/create')
const NoticeDetail = () => import('@/views/notice/detail')
const CurrentCreate = () => import('@/views/current/create')
const CurrentDetail = () => import('@/views/current/detail')
const Search = () => import('@/views/search')
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

const TopicDetailRoute = {
  path: 'topic/:id',
  name: 'TopicDetail',
  component: TopicDetail,
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

const NoticeCreateRoute = {
  path: 'notice/create',
  name: 'NoticeCreate',
  component: NoticeCreate,
  meta: {
    requiresAuth: true
  }
}

const NoticeDetailRoute = {
  path: 'notice/:id',
  name: 'NoticeDetail',
  component: NoticeDetail,
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

const CurrentDetailRoute = {
  path: 'current/:id',
  name: 'CurrentDetail',
  component: CurrentDetail,
  meta: {
    requiresAuth: false
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
    TopicDetailRoute,
    ShopRoute,
    ProductDetailRoute,
    ShoppingCartRoute,
    NoticeCreateRoute,
    NoticeDetailRoute,
    CurrentCreateRoute,
    CurrentDetailRoute,
    SearchRoute,
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
